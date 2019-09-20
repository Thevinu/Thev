using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace Circuits
{
    class OR:Gate
    {
        public OR(int x, int y) : base(x, y)
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
                paper.DrawImage(Properties.Resources.OrGateAllRed, left, top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.OrGate, left, top);
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
            pins[0].X = x - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT ;
            pins[2].X = x + WIDTH + 4*GAP +5;
            pins[2].Y = y + HEIGHT - 14;
        }

    }
}
