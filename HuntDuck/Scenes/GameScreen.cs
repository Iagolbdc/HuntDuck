using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class GameScreen : IScreen
{
    private Player _player;
    private GameObject _background;    
    private GameObject _tree; 
    public void Draw(SpriteBatch spriteBatch)
    {
        _player.Draw(spriteBatch);
        
        _tree.Draw(spriteBatch);
        _background.Draw(spriteBatch);
    }

    public void Initialize()
    {
        _player.Initialize();

        _background.Initialize();
        _background.Position = new Point(0,-120);

        _tree.Initialize();
        _tree.Position = new Point(120, 130);
    }

    public void LoadContent(ContentManager content)
    {
        Dictionary<string, Texture2D[]> playerAnimations = new Dictionary<string, Texture2D[]>();
        
        playerAnimations["move_left"] = new Texture2D[] { content.Load<Texture2D>("assets/images/duck/black/left/0"), content.Load<Texture2D>("assets/images/duck/black/left/1"), content.Load<Texture2D>("assets/images/duck/black/left/2") };
        playerAnimations["move_right"] = new Texture2D[] { content.Load<Texture2D>("assets/images/duck/black/right/0"), content.Load<Texture2D>("assets/images/duck/black/right/1"), content.Load<Texture2D>("assets/images/duck/black/right/2") };
        playerAnimations["move_left_up"] = new Texture2D[] { content.Load<Texture2D>("assets/images/duck/black/top-left/0"), content.Load<Texture2D>("assets/images/duck/black/top-left/1"), content.Load<Texture2D>("assets/images/duck/black/top-left/2") };
        playerAnimations["move_right_up"] = new Texture2D[] { content.Load<Texture2D>("assets/images/duck/black/top-right/0"), content.Load<Texture2D>("assets/images/duck/black/top-right/1"), content.Load<Texture2D>("assets/images/duck/black/top-right/2") };
        playerAnimations["dead"] = new Texture2D[] { content.Load<Texture2D>("assets/images/duck/black/dead/0"), content.Load<Texture2D>("assets/images/duck/black/dead/1"), content.Load<Texture2D>("assets/images/duck/black/dead/2") };
        playerAnimations["shot"] = new Texture2D[] { content.Load<Texture2D>("assets/images/duck/black/shot/0") };
      
        _player = new Player(playerAnimations);

        Texture2D background = content.Load<Texture2D>("assets/images/scene/back/0");
        _background = new GameObject(background);

        Texture2D tree = content.Load<Texture2D>("assets/images/scene/tree/0");
        _tree = new GameObject(tree);
    }

    public void Update(float deltaTime)
    {
        _player.Update(deltaTime);

        if(Input.GetKeyDown(Keys.Escape)){
            Globals.GameInstance.ChangeScreen(EScreen.Menu);
        }
    }
}