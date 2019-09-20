using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Circuits
{
    public abstract class Gate
    {
        protected bool selected = false;

        protected int left;

        // top is the top of the whole gate
        protected int top;

        // width and height of the main part of the gate
        protected const int WIDTH = 40;
        protected const int HEIGHT = 40;
        
        // length of the connector legs sticking out left and right
        protected const int GAP = 10;

        //protected Brush selectedBrush = Brushes.Red;
        //protected Brush normalBrush = Brushes.LightGray;

        private int _x;
        private int _y;

        protected List<Pin> pins = new List<Pin>();


        public Gate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// True if the given (x,y) position is roughly
        /// on top of this gate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract bool IsMouseOn(int x, int y);

        public abstract void Draw(Graphics paper);


      
        public abstract void MoveTo(int x, int y);


        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public int Left
        {
            get { return left; }
        }

        public int Top
        {
            get { return top; }
        }

        public List<Pin> Pins
        {
            get { return pins; }
        }
    }
}
