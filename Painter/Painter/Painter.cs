using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Painter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Painter : GameEnvironment
    {
        public const String playingState = "playingState", gameoverState = "gameoverState";
        public const int maxLives = 3;

        public Painter()
        {
            Content.RootDirectory = "Content";
        }


        protected override void LoadContent()
        {
            base.LoadContent();
            this.IsMouseVisible = true;
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            assetManager.PlayMusic("snd_music");

            gameStateManager.AddGameState(playingState, new PainterGameWorld());
            gameStateManager.AddGameState(gameoverState, new GameOverGameState());
            gameStateManager.SwitchTo(playingState);
        }



    }
}
