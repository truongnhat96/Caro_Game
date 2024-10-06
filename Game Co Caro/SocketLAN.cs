using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Co_Caro
{

    public class SocketLAN
    {
        #region Server

        Socket server;

        public void CreateServer()
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP), Port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipe);
            server.Listen(10);

            Task.Run(() => client = server.Accept());
        }

        public void StopServerOrClient()
        {
            if (server != null)
            {
                server.Close();
                server = null;
            }

            if (client != null)
            {
                client.Close();
                client = null;
            }
        }


        #endregion

        #region Client
        Socket client;

        public bool ConnectServer()
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP), Port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(ipe);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Server and Client

        public string IP = "127.0.0.1";
        public int Port = 9999;
        public bool IsServer = true;


        /// <summary>
        ///Client gửi dữ liệu đến server    
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Send(object data)
        {
            byte[] sender = CompressData(data);

            return SendData(client, sender);
        }


        /// <summary>
        /// server nhận dữ liệu từ client, xử lý và trả về kết quả
        /// </summary>
        /// <returns></returns>
        public object Receive()
        {
            byte[] receiver = new byte[1024];
            bool ok = ReceiveData(client, receiver);
            return DecompressData(receiver);
        }


        private bool SendData(Socket target ,byte[] data)
        {
            try
            {
                return target.Send(data) == 1 ? true : false;
            }
            catch
            {
                return false;
            }

        }

        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

        /// <summary>
        /// Nén dữ liệu trước khi gửi
        /// </summary>
        /// <param name="data">Dữ liệu của client</param>
        /// <returns>Dữ liệu đã được nén thành mảng byte</returns>
        private byte[] CompressData(object data)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, data);
            return ms.ToArray();
        }


        /// <summary>
        /// Giải nén dữ liệu sau khi nhận
        /// </summary>
        /// <param name="data">Dữ liệu được nén từ client</param>
        /// <returns>Dữ liệu của client được giải nén</returns>
        private object DecompressData(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            BinaryFormatter bf = new BinaryFormatter();
            ms.Position = 0;
            return bf.Deserialize(ms);
        }


        /// <summary>
        /// Lấy địa chỉ IP của máy local
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string Address = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Address = ip.Address.ToString();
                        }
                    }
                }
            }
            return Address;
        }

        #endregion
    }
}
