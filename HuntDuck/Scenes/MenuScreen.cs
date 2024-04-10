using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class MenuScreen : IScreen
{
    private Button _playButton;
    private Button _exitButton;
    private SpriteFont _font;
    private GameObject _logoImage;
    private Vector2 pos;
    public void Draw(SpriteBatch spriteBatch)
    {
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
        _logoImage.Draw(spriteBatch); 
        spriteBatch.DrawString(_font, "top score = 99999", pos,  Color.White);
    }

    public void Initialize()
    {
        _playButton.Initialize();
        _playButton.Position = new Point(350,270);
        
        _exitButton.Initialize();
        _exitButton.Position = new Point(350,320);
        
        _logoImage.Initialize();
        _logoImage.Position = new Point(150, 0);

        pos = new Vector2(290, 400);

    }

    public void LoadContent(ContentManager content)
    {
        _playButton = new Button(content.Load<Texture2D>("play_button"), Play);
        
        _exitButton = new Button(content.Load<Texture2D>("exit_button"), Exit);

        _logoImage = new GameObject(content.Load<Texture2D>("assets/images/logo/logo"), new Rectangle(0, 0,500,250));

        _font = content.Load<SpriteFont>("DuckHuntFont");
    }

    public void Update(float deltaTime)
    {
        _playButton.Update(deltaTime);
        _exitButton.Update(deltaTime);
        _logoImage.Update(deltaTime);
    }

    public void Play(){
        Globals.GameInstance.ChangeScreen(EScreen.Game);
    }

    public void Exit(){
        Globals.GameInstance.Exit();
    }
}