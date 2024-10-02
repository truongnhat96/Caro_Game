using System.Windows.Forms;

namespace Game_Co_Caro
{
    public class Chess
    {
        public Label lb;
        public int X { get; set; }
        public int Y { get; set; }
        public Chess()
        {
            lb = new Label();
        }
        public Chess(Label _lb, int x, int y)
        {
            lb = new Label();
            lb = _lb;
            X = x;
            Y = y;
        }
    }
}
