using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs
    /// and one output.
    /// </summary>
    public class AndGate:Gate
    {
       
        /// <summary>
        /// This is the list of all the pins of this gate.
        /// An AND gate always has two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        

        

        public AndGate(int x, int y):base(x,y)
        {
            pins.Add(new Pin(this, true, 20));
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
                paper.DrawImage(Properties.Resources.AndGateAllRed, left, top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.AndGate, left, top);
            }
            foreach (Pin p in pins)
                p.Draw(paper);

        }

        public override void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x - 2*GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x - 2 * GAP;
            pins[1].Y = y + HEIGHT;
            pins[2].X = x + WIDTH + 3 * GAP;
            pins[2].Y = y + HEIGHT / 2 + 6;
        }
    }
}
