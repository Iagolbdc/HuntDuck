using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Aula6;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameObject _background;
    private GameObject[] _platforms;
    private Portal _portal;
    private Player _player;

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

        _player.Initialize();
        _background.Initialize();

        _platforms[0].Position = new Point(0,390);
        _platforms[1].Position = new Point(400,390);
        _platforms[2].Position = new Point(0,292);

        _portal.Position = new Point(500,300);

        Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
        Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D backgroungImage = Content.Load<Texture2D>("background");
        _background = new GameObject(backgroungImage);

        Texture2D platformImage1 = Content.Load<Texture2D>("platform1");
        Texture2D platformImage2 = Content.Load<Texture2D>("platform2");
        _platforms = new GameObject[3]{
            new GameObject(platformImage1), new GameObject(platformImage2),new GameObject(platformImage2),
        };

        Texture2D portalImage = Content.Load<Texture2D>("portal");
        _portal = new Portal(portalImage);

        Texture2D playerImage = Content.Load<Texture2D>("player");
        _player = new Player(playerImage);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _player.Update(deltaTime);

        _portal.CheckCollision(_player);

        Input.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _background.Draw(_spriteBatch);

        foreach (GameObject item in _platforms)
        {
            item.Draw(_spriteBatch);
        }

        _portal.Draw(_spriteBatch);

        _player.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
