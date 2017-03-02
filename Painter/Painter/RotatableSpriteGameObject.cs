using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Painter
{
    class RotatableSpriteGameObject : SpriteGameObject
    {
        private float angle;

        public RotatableSpriteGameObject(string assetname, int layer = 0, string id = "", int sheetIndex = 0) : base(assetname, layer, id, sheetIndex)
        {
            angle = -0.5f;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!visible || sprite == null) return;
            spriteBatch.Draw(sprite.Sprite, new Rectangle((int) this.GlobalPosition.X,(int) this.GlobalPosition.Y,sprite.Width,sprite.Height), null, Color.White, angle, this.Origin, SpriteEffects.None, 0);
        }

        public float Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public override void Reset()
        {
            this.angle = -0.5f;
            base.Reset();
        }
    }
}
