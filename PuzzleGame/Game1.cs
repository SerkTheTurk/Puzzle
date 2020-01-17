using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PuzzleGame.Desktop
{
    public class Game1 : Game
    {
        public static int HEIGHT = 768;
        public static int WIDTH = 1280;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static GameState gameState;
        Menu menu;
        Level lvl1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            gameState = GameState.MENU;
            menu = new Menu();
            lvl1 = new Level("Content/testlvl.csv");
            lvl1.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            lvl1.LoadContent(Content);
            menu.LoadContent(Content);

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || gameState == GameState.EXIT)
                Exit();
                

            menu.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.MENU:
                    menu.Draw(spriteBatch);
                    break;
                case GameState.LEVEL1:
                    lvl1.Draw(spriteBatch);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
