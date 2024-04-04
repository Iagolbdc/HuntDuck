using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Portal : GameObject{
    public Portal(Texture2D image) : base(image){

    }

    public void CheckCollision(Player player){
        if(_bounds.Intersects(player.Bounds)){
            player.Position = Position - new Point(500,100);
        }
    }
}