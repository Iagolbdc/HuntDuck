using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class MenuScreen : IScreen
{
    private Button _playButton;
    private Button _exitButton;
    private SpriteFont _font;
    public void Draw(SpriteBatch spriteBatch)
    {
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
    }

    public void Initialize()
    {
        _playButton.Initialize();
        _playButton.Position = new Point(350,200);
        _exitButton.Initialize();
        _exitButton.Position = new Point(350,250);

        
    }

    public void LoadContent(ContentManager content)
    {
        _playButton = new Button(content.Load<Texture2D>("play_button"), Play);
        
        _exitButton = new Button(content.Load<Texture2D>("exit_button"), Exit);
    }

    public void Update(float deltaTime)
    {
        _playButton.Update(deltaTime);
        _exitButton.Update(deltaTime);
    }

    public void Play(){
        Globals.GameInstance.ChangeScreen(EScreen.Game);
    }

    public void Exit(){
        Globals.GameInstance.Exit();
    }
}