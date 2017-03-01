using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Painter
{
    class GameWorld : GameObjectList
    {
        ThreeColorGameObject cannon;
        RotatableSpriteGameObject cannon_barrel;

        public GameWorld()
        {
            cannon = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_blue", "spr_cannon_green");
            cannon.Position = new Vector2(58, 388);
            cannon_barrel = new RotatableSpriteGameObject("spr_cannon_barrel");
            cannon_barrel.Position = new Vector2(74, 404);
            cannon_barrel.Origin = new Vector2(34, 34);

            this.Add(new SpriteGameObject("spr_background"));

            this.Add(cannon_barrel);
            this.Add(cannon);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.R))
                cannon.Color = Color.Red;
            else if (inputHelper.KeyPressed(Keys.G))
                cannon.Color = Color.Green;
            else if (inputHelper.KeyPressed(Keys.B))
                cannon.Color = Color.Blue;

            double opposite = inputHelper.MousePosition.Y - cannon_barrel.GlobalPosition.Y;
            double adjacent = inputHelper.MousePosition.X - cannon_barrel.GlobalPosition.X;
            cannon_barrel.Angle = (float)Math.Atan2(opposite, adjacent);


        }
    }
}
