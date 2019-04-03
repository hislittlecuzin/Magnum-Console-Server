using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Following was verbatum before the Networking in the namespace.
//Console_Server_V1.
namespace Networking
{
    static class TCPMaster
    {
        static Thread mapRequest;

        public static void StartTCPMasterServer() {
            Console.WriteLine("Server starting..");
            mapRequest = new Thread(MapRequest);
            mapRequest.Start();
        }


        static void MapRequest() {
            TcpListener listener = new TcpListener(1984);
            Console.WriteLine("listening...");
            listener.Start();
            while (Console_Server_V1.Program.loopConsole) {
                TcpClient client = listener.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                
                try {
                    string request = sr.ReadLine();
                    Console.WriteLine(request);
                    string[] tokens = request.Split(' ');
                    if (tokens[0] == "LOAD") {
                        LoadArea(ref sw, tokens[2]);
                        client.Close();
                    } else if (tokens[0] == "TALK") {
                        string[] argument = new[] { tokens[3], tokens[5] };
                        ReadTalk(ref sw, ref tokens[1], ref argument);
                        client.Close();
                    }
                }
                catch {
                    Console.WriteLine("ERROR!");
                }
            }
        }

        static void ReadTalk(ref StreamWriter sw, ref string toWhom, ref string[] words) {
            //Base.GameControl.peopleDatabase[Convert.ToInt32(toWhom)].HearTalk(ref sw, Convert.ToInt32(words[0]), Convert.ToInt32(words[1]));
        }

        public static void SayBack(ref StreamWriter sw, string response) {
            sw.WriteLine("SAY " + response);
            sw.Flush();
        }

        static void LoadArea(ref StreamWriter sw, string area) {
            //translates string to the enumeration value of string. 
            Base.AreaNames curArea;
            Enum.TryParse(area, out curArea);

            int xArea = 0;
            int yArea = 0;

            bool looping = true;

            for(int x = 0; x < Base.GameControl.areasInUse.GetLength(0) && looping; x ++) {
                for (int y = 0; y < Base.GameControl.areasInUse.GetLength(1) && looping; y++)
                {
                    if (Base.GameControl.areasInUse[x, y].GetName() == curArea) {
                        looping = false;
                        xArea = x;
                        yArea = y;
                    }
                }
            }

            int height = Base.GameControl.areasInUse[xArea, yArea].GetLocationHeight();
            int width = Base.GameControl.areasInUse[xArea, yArea].GetLocationWidth();

            //sw.WriteLine("!Location ");
            sw.Flush();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++) {
                    Base.LocationTile lT = Base.GameControl.areasInUse[xArea,yArea].GetLocationTile(x, y);
                    sw.Write((int)lT.GetGround());
                    sw.Write((int)lT.GetStructure());
                    sw.Write((int)lT.GetStructureAttribute());
                    sw.Write((int)lT.GetIndividualInTile());
                    sw.Write(";");

                    //sw.Write(lT.GetGround().ToString() + lT.GetStructure().ToString() + lT.GetStructureAttribute().ToString() + lT.GetIndividualInTile().ToString() + ";");
                    sw.Flush();
                }
                sw.Write("\n");
                sw.Flush();
            }

            Console.WriteLine("Doing Individuals");
            //Individuals
            //ID number THEN name number
            sw.WriteLine("!Individuals");
            int individualCount = Base.GameControl.areasInUse[xArea, yArea].GetTotalIndividual();
            Console.WriteLine(individualCount);
            for (int i = 0; i < individualCount; i++) {
                Console.WriteLine("Doing Individual number" + i);
                int currentPerson = Base.GameControl.areasInUse[xArea, yArea].GetIndividual(i);
                sw.Write(currentPerson);
                sw.Write(" ");
                sw.Write((int)Base.GameControl.peopleDatabase[currentPerson].GetFirstName());
                sw.Write("\n");
                sw.Flush();
            }
            Console.WriteLine("Completed");
        }


        

        /*
        static TcpListener server;
        static int port = 1984;
        static List<TCPClient> tCPClients;
        static List<TCPClient> disconnectionList;

        static Thread serverThread;


        public static void StartTCPMasterServer() {
            tCPClients = new List<TCPClient>();
            disconnectionList = new List<TCPClient>();
            serverThread = new Thread(ServerLoop);
            


            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            server.BeginAcceptTcpClient(AcceptTcpClient, server);

        }

        static void ServerLoop() {
            try
            {
                while (Console_Server_V1.Program.loopConsole)
                {
                    foreach (TCPClient curClient in tCPClients)
                    {
                        if (!IsConnected(curClient))
                        {
                            curClient.GetClient().Close();
                            disconnectionList.Add(curClient);
                            Console.WriteLine("Someone has disconnected.");
                            continue;
                        }
                        else
                        {
                            NetworkStream s = curClient.GetClient().GetStream();
                            if (s.DataAvailable)
                            {
                                StreamReader sr = new StreamReader(s, true);
                                string data = sr.ReadLine();
                                if (data != null)
                                    OnIncomingData(curClient, data);
                            }
                        }
                    }
                }
            }
            catch (Exception except) {
                Console.WriteLine(except);
            }
        }

        #region ClientManagment

        static void OnIncomingData(TCPClient c, string data)
        {
            Console.WriteLine()
            if (data.Contains("!location")) {
                Base.AreaNames area;
                string areaName = data.Split(';')[1];
                Console.WriteLine(areaName);
                Enum.TryParse(areaName, out area);
                c.SetArea(area);
            }
            if (data.Contains("&NAME"))
            {
                //c.GetClient().clientName = data.Split('|')[1];
                //Broadcast(c.clientName + " has connected ", clients);
                return;
            }

            //Broadcast(c.clientName + " : " + data, clients);
        }


        static bool IsConnected(TCPClient c)
        {
            try
            {
                if (c != null && c.GetClient().Client != null && c.GetClient().Client.Connected)
                {
                    if (c.GetClient().Client.Poll(0, SelectMode.SelectRead))
                    {
                        return !(c.GetClient().Client.Receive(new byte[1], SocketFlags.Peek) == 0);
                    }
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region ClientAcceptance
        static void StartListeningToTCP() {
            server.BeginAcceptTcpClient(AcceptTcpClient, server);
        }

        static void AcceptTcpClient(IAsyncResult ar)
        {
            TcpListener listenter = (TcpListener)ar.AsyncState;
            TCPClient newClient = new TCPClient(listenter.EndAcceptTcpClient(ar));

            tCPClients.Add(newClient);
            StartListeningToTCP();

            Console.WriteLine(newClient + " Has connected.");
            //Send a message to everyone , say someone has connected
            //Broadcast("%NAME", new List<ServerClient>() { clients[clients.Count - 1] });// + " has connected ", clients);
        }
        #endregion
        */
    }



}
