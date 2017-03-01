using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painter
{
    class Ball : ThreeColorGameObject
    {
        public Ball(string colorRed = "spr_ball_red", string colorBlue = "spr_ball_blue", string colorGreen = "spr_ball_green") : base(colorRed, colorBlue, colorGreen)
        {

        }

        public bool Shooting { get; set; }

        public override void Reset()
        {
            base.Reset();
        }
    }
}
