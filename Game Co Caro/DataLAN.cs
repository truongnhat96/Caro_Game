using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Co_Caro
{
    [Serializable]
    public class DataLAN
    {
        private int command;
        private string message;
        private Point point;

        public DataLAN(int command, string message, Point point)
        {
            this.Command = command;
            this.Message = message;
            this.Point = point;
        }

        public int Command { get => command; set => command = value; }
        public string Message { get => message; set => message = value; }
        public Point Point { get => point; set => point = value; }
    }

    public enum CommandList
    {
        SEND_POINT,
        NOTIFY,
        MESSAGE,
        NEW_GAME,
        UNDO,
        END_GAME,
        QUIT
    }
}
