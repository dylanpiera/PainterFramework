using Microsoft.Xna.Framework;
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
            this.Reset();
        }

        public bool Shooting { get; set; }

        public override void Reset()
        {
            visible = false;
            Shooting = false;
            velocity = Vector2.Zero;

            
        }

        public void Shoot(InputHelper inputHelper, ThreeColorGameObject cannonColor, RotatableSpriteGameObject cannonBarrel)
        {
            Shooting = true;
            this.Color = cannonColor.Color;
            velocity = (inputHelper.MousePosition - cannonColor.GlobalPosition) * 1.2f;
            float opp = (float)Math.Sin(cannonBarrel.Angle) * cannonBarrel.Width * 0.6f;
            float adj = (float)Math.Cos(cannonBarrel.Angle) * cannonBarrel.Width * 0.6f;
            Position = cannonColor.Position + new Vector2(adj, opp) + new Vector2(3, 3);
            Visible = true;
            Painter.AssetManager.PlaySound("snd_shoot_paint");
        }

        public override void Update(GameTime gameTime)
        {
            if (Shooting)
            {
                velocity.X *= 0.99f;
                velocity.Y += 6;
            }

            PainterGameWorld GW = GameWorld as PainterGameWorld;
            if(GW.IsOutsideWorld(position))
            {
                Reset();
            }

            base.Update(gameTime);
        }
    }
}
