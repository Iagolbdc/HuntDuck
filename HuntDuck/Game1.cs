using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HuntDuck;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private GameObject _background;
    private Texture2D[] _players;
    

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

        Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
        Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Dictionary<string, Texture2D[]> playerAnimations = new Dictionary<string, Texture2D[]>();
        playerAnimations["idle"] = new Texture2D[] { Content.Load<Texture2D>("assets/images/duck/black/left/0") };
        playerAnimations["move_left"] = new Texture2D[] { Content.Load<Texture2D>("assets/images/duck/black/left/0"), Content.Load<Texture2D>("assets/images/duck/black/left/1"), Content.Load<Texture2D>("assets/images/duck/black/left/2") };
        playerAnimations["move_right"] = new Texture2D[] { Content.Load<Texture2D>("assets/images/duck/black/right/0"), Content.Load<Texture2D>("assets/images/duck/black/right/1"), Content.Load<Texture2D>("assets/images/duck/black/right/2") };
        playerAnimations["move_left_up"] = new Texture2D[] { Content.Load<Texture2D>("assets/images/duck/black/top-left/0"), Content.Load<Texture2D>("assets/images/duck/black/top-left/1"), Content.Load<Texture2D>("assets/images/duck/black/top-left/2") };
        playerAnimations["move_right_up"] = new Texture2D[] { Content.Load<Texture2D>("assets/images/duck/black/top-right/0"), Content.Load<Texture2D>("assets/images/duck/black/top-right/1"), Content.Load<Texture2D>("assets/images/duck/black/top-right/2") };
        playerAnimations["dead"] = new Texture2D[] { Content.Load<Texture2D>("assets/images/duck/black/dead/0"), Content.Load<Texture2D>("assets/images/duck/black/dead/1"), Content.Load<Texture2D>("assets/images/duck/black/dead/2") };
        playerAnimations["shot"] = new Texture2D[] { Content.Load<Texture2D>("assets/images/duck/black/shot/0") };
      
        _player = new Player(playerAnimations);

        Texture2D background = Content.Load<Texture2D>("background");
        _background = new GameObject(background);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _player.Update(deltaTime);
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _background.Draw(_spriteBatch);
        _player.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
