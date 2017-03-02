using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Painter
{
    class PainterGameWorld : GameObjectList
    {
        ThreeColorGameObject cannon;
        RotatableSpriteGameObject cannon_barrel;
        PaintCan can1, can2, can3;
        Ball ball;
        TextGameObject scoreObj;
        GameObjectList livesObj;

        int lives, score;

        public PainterGameWorld()
        {
            scoreObj = new TextGameObject("GameFont");
            scoreObj.Text = "";
            scoreObj.Position = new Vector2(24,6);
            SpriteGameObject scoreBar = new SpriteGameObject("spr_scorebar");
            livesObj = new GameObjectList();
            cannon = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_blue", "spr_cannon_green");
            cannon.Position = new Vector2(58, 388);
            cannon_barrel = new RotatableSpriteGameObject("spr_cannon_barrel");
            cannon_barrel.Position = new Vector2(74, 404);
            cannon_barrel.Origin = new Vector2(34, 34);

            can1 = new PaintCan(Color.Red,450f);
            can2 = new PaintCan(Color.Green, 575f);
            can3 = new PaintCan(Color.Blue, 700f);

            ball = new Ball();

            for (int i = 0; i < Painter.maxLives; i++)
            {
                SpriteGameObject life = new SpriteGameObject("spr_lives", 0, i.ToString());
                life.Position = new Vector2(i * life.BoundingBox.Width, 30);
                livesObj.Add(life);

            }

            this.Score = 0;
            this.Lives = Painter.maxLives;

            this.Add(new SpriteGameObject("spr_background"));
            this.Add(scoreBar);
            this.Add(ball);
            this.Add(can1);
            this.Add(can2);
            this.Add(can3);
            this.Add(cannon_barrel);
            this.Add(cannon);
            this.Add(scoreObj);
            this.Add(livesObj);

        }

        public int Lives
        {
            get
            {
                return lives;
            }

            set
            {
                if (value > Painter.maxLives) return;

                for (int i = 0; i < Painter.maxLives; i++)
                {
                    livesObj.Find(i.ToString()).Visible = (i < value);
                }

                lives = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
                if (scoreObj != null)
                {
                    scoreObj.Text = "Score: " + value;
                }
            }
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

            if(inputHelper.MouseLeftButtonPressed() && !this.ball.Shooting)
            {
                ball.Shoot(inputHelper, cannon, cannon_barrel);
            }
        }

        public override void Update(GameTime gameTime)
        {
            checkCanCollision(can1); checkCanCollision(can2); checkCanCollision(can3);

            if(this.lives <= 0)
            {
                this.Reset();
                Painter.GameStateManager.SwitchTo(Painter.gameoverState);
            }
           
            base.Update(gameTime);
        }

        private void checkCanCollision(PaintCan can)
        {
            if(this.ball.CollidesWith(can) && ball.Shooting)
            {
                can.Color = this.ball.Color;
                this.ball.Reset();
            }
        }


        public bool IsOutsideWorld(Vector2 position)
        {
            if((position.X <= 0 || position.X >= Painter.Screen.X) || position.Y >= Painter.Screen.Y) return true;
            
            return false;
        }

        public override void Reset()
        {
            this.Lives = Painter.maxLives;
            this.Score = 0;
            this.can1.Reset();
            this.can2.Reset();
            this.can3.Reset();
            this.cannon.Reset();
            this.cannon_barrel.Reset();

            base.Reset();
        }



    }
}
