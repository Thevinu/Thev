using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Circuits
{
    class NOT:Gate
    {

        public NOT(int x, int y) : base(x, y)
        {
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));         
            MoveTo(x, y); // move the gate and position the pins
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
                paper.DrawImage(Properties.Resources.NotGateAllRed, left, top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.NotGate, left, top);
            }
            foreach (Pin p in pins)
                p.Draw(paper);

            // AND is simple, so we can use a circle plus a rectange.
            // An alternative would be to use a bitmap.

            
           
        }
     

        public override void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x - 2*GAP;
            pins[0].Y = y + HEIGHT/2 + 5;
            pins[1].X = x + HEIGHT + 3*GAP;
            pins[1].Y = y + HEIGHT / 2 + 5;
            
        }

    }
}
