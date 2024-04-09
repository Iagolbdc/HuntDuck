using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Button : GameObject
{
    private Action _callBack;
    public Button(Texture2D image, Action callBack) : base(image)
    {
        _callBack = callBack;
    }

    public override void Update(float deltaTime)
    {
        MouseState mouseState = Mouse.GetState();

        if(mouseState.LeftButton == ButtonState.Pressed){
            if(_bounds.Contains(mouseState.Position)){
                _callBack.Invoke();
            }
        }
    }
}