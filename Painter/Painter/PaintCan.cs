using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painter
{
    class PaintCan : ThreeColorGameObject
    {
        Color targetColor;
        float minVelocity;
        float hPosOffset;

        public PaintCan(Color targetColor, float hPosOffset, string colorRed = "spr_can_red", string colorBlue = "spr_can_blue", string colorGreen = "spr_can_green") : base(colorRed, colorBlue, colorGreen)
        {
            this.targetColor = targetColor;
            this.hPosOffset = hPosOffset;
            this.minVelocity = 30;
            this.Reset();
        }

        public override void Reset()
        {
            base.Reset();
            position = new Vector2(this.hPosOffset, - BoundingBox.Height);
            velocity = Vector2.Zero;
            
        }

        public override void Update(GameTime gameTime)
        {
            if (velocity.Y == 0.0f && GameEnvironment.Random.NextDouble() < 0.01)
            {
                velocity = GenerateRandomVelocity();
                Color = generateRandomColor();
            }
            minVelocity += 0.001f;

            PainterGameWorld GW = GameWorld as PainterGameWorld;
            if (GW.IsOutsideWorld(GlobalPosition))
            {
                if (this.Color == this.targetColor)
                {
                    GW.Score += 10;
                    Painter.AssetManager.PlaySound("snd_collect_points");
                }
                else GW.Lives--;

                this.Reset();
            } 

            base.Update(gameTime);
        }

        public Vector2 GenerateRandomVelocity()
        {
            return new Vector2(0.0f, (float)GameEnvironment.Random.NextDouble() * 30 + minVelocity);
        }

        public Color generateRandomColor()
        {
            switch (GameEnvironment.Random.Next(3))
            {
                case 0:
                    return Color.Red;
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Green;
                default:
                    return Color.Red;
            }
        }
    }
}
