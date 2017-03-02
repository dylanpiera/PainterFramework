using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painter
{
    class Cannon : GameObjectList
    {
        ThreeColorGameObject cannonColor;
        RotatableSpriteGameObject cannon_barrel;

        public Cannon()
        {
            cannonColor = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_blue", "spr_cannon_green");
            cannonColor.Position = new Vector2(52, 398);
            cannon_barrel = new RotatableSpriteGameObject("spr_cannon_barrel");
            cannon_barrel.Position = new Vector2(74, 404);
            cannon_barrel.Origin = new Vector2(34, 34);
        }

        internal ThreeColorGameObject CannonColor
        {
            get
            {
                return cannonColor;
            }

            set
            {
                cannonColor = value;
            }
        }

        internal RotatableSpriteGameObject Cannon_barrel
        {
            get
            {
                return cannon_barrel;
            }

            set
            {
                cannon_barrel = value;
            }
        }
    }
}
