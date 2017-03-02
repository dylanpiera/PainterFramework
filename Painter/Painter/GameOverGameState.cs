using Microsoft.Xna.Framework;

namespace Painter
{
    class GameOverGameState : GameObjectList
    {
        private TextGameObject textObj;

        public GameOverGameState()
        {
            textObj = new TextGameObject("GameFont");
            textObj.Text = "Game over! Press any key to restart...";
            textObj.Position = new Vector2((Painter.Screen.X/6), (Painter.Screen.Y/2)-10);
            this.Add(textObj);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            
            

            if (inputHelper.AnyKeyPressed) Painter.GameStateManager.SwitchTo(Painter.playingState);


        }
    }
}