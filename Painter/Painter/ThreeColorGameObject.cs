using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painter
{
    class ThreeColorGameObject : RotatableSpriteGameObject
    {
        SpriteSheet colorRed, colorBlue, colorGreen;
        Color color;
        

        public ThreeColorGameObject(String colorRed, String colorBlue, String colorGreen) : base("")
        {
            this.colorRed = new SpriteSheet(colorRed);
            this.colorBlue = new SpriteSheet(colorBlue);
            this.colorGreen = new SpriteSheet(colorGreen);
            Color = Color.Blue;
        }

        public override void Reset()
        {
            base.Reset();
            Color = Color.Blue;
        }

        public Color Color
        {
            get { return color; }
            set
            {
                if (value != Color.Red && value != Color.Green && value != Color.Blue)
                {
                    return;
                }
                color = value;
                if (color == Color.Red) sprite = colorRed;
                else if (color == Color.Green) sprite = colorGreen;
                else if (color == Color.Blue) sprite = colorBlue;
            }
        }

    }
}
