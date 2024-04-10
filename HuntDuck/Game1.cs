using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HuntDuck;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IScreen _menuScreen;
    private IScreen _gameScreen;
    private IScreen _currentScreen; 
    private Color _backgroundColor;

    public void ChangeScreen(EScreen screenType){
        switch (screenType)
        {
            case EScreen.Menu:
                _currentScreen = _menuScreen;
                _backgroundColor = Color.Black;
                break;
            case EScreen.Game:
                _currentScreen = _gameScreen;
                _backgroundColor = Color.SkyBlue;
                break;
        }
        _currentScreen.Initialize();
    }

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();

        Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
        Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;
        Globals.GameInstance = this;
        _currentScreen.Initialize();

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _menuScreen = new MenuScreen();
        _menuScreen.LoadContent(Content);

        _gameScreen = new GameScreen();
        _gameScreen.LoadContent(Content);

        _currentScreen = _menuScreen;

    }

    protected override void Update(GameTime gameTime)
    {
        // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        //     Exit();

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _currentScreen.Update(deltaTime);
        
        Input.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_backgroundColor);

        _spriteBatch.Begin();

        _currentScreen.Draw(_spriteBatch);
        
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
