using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace PuzzleGame.Desktop
{
    public class Menu
    {
        Texture2D play;
        Texture2D quit;
        int selected;
        KeyboardState ks;

        public Menu()
        {
            selected = 0;
        }

        public void LoadContent(ContentManager content)
        {
            quit = content.Load<Texture2D>("quitBtn");
            play = content.Load<Texture2D>("playBtn");
        }

        public void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();

            if (selected == 0)
            {
                if (ks.IsKeyDown(Keys.Down))
                    selected = 1;
                if (ks.IsKeyDown(Keys.Enter))
                    Game1.gameState = GameState.LEVEL1;
            }
            if (selected == 1)
            {
                if (ks.IsKeyDown(Keys.Up))
                    selected = 0;
                if (ks.IsKeyDown(Keys.Enter))
                    Game1.gameState = GameState.EXIT;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (selected == 1)
            {
                sb.Draw(play, new Vector2(Game1.WIDTH/2-play.Width/2, 250), Color.Gray);
                sb.Draw(quit, new Vector2(Game1.WIDTH / 2 - play.Width / 2, 400), Color.White);
            }
            if (selected == 0)
            {
                sb.Draw(play, new Vector2(Game1.WIDTH / 2 - play.Width / 2, 250), Color.White);
                sb.Draw(quit, new Vector2(Game1.WIDTH / 2 - play.Width / 2, 400), Color.Gray);
            }
        }
    }
}
