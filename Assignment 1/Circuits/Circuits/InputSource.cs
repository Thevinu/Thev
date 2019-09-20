using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;


namespace Circuits
{
    class InputSource : Gate
    {
        public InputSource(int x, int y) : base(x, y)
        {
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y);
        }

        public override bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + WIDTH
                && top <= y && y < top + HEIGHT)
                return true;
            else
                return false;
        }

        public override void Draw(Graphics paper)
        {
            if (selected)
            {
                paper.DrawImage(Properties.Resources.Input_Yellow, left, top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.Input, left, top);
            }
            foreach (Pin p in pins)
                p.Draw(paper);
        }

        public override void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;
          
        }
    }
}

