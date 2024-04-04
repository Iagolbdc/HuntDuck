using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : GameObject{
    private const float SPEED_X = 200;
    private const float GRAVITY = 10;
    private float _speedY;
    private const float JUMP_VELOCITY = -5;
    private Rectangle _previousBounds;
    public float directionX = -1;
    public float directionY = 0;

    public Player(Texture2D image) : base(image){

    }

    public override void Initialize(){
        _bounds.X = 150;
        _bounds.Y = 347;
        _speedY = 0;
    }

    public override void Update(float deltaTime)
    {
        directionY = 0;

        _previousBounds = _bounds;

        Console.WriteLine($"{_bounds.Y + _image.Height} || {Globals.SCREEN_HEIGHT}");

        if(Input.GetKey(Keys.W) && _bounds.Y > 0.0f ){
            directionY = -1.0f;
        }

        if(Input.GetKey(Keys.S) && _bounds.Y < Globals.SCREEN_HEIGHT - _image.Height){
            directionY = 1.0f;
        }

        if(directionY != 0){
            _bounds.Y = _bounds.Y + (int)(directionY * SPEED_X * deltaTime);
        }

        if(_bounds.X + _image.Width > Globals.SCREEN_WIDTH ){
            directionX = -1.0f;
        }
        
        if(_bounds.X < 0.0f){
            directionX = 1.0f;
        }

        if(directionX != 0){
            _bounds.X = _bounds.X + (int)(directionX * SPEED_X * deltaTime);
        }
        
        if(_speedY == 0 && Input.GetKeyDown(Keys.Space)){
            _speedY = JUMP_VELOCITY;
        }

        // _speedY = _speedY + (GRAVITY * deltaTime);
        // _bounds.Y = _bounds.Y + (int)_speedY;
    }

    public void CheckBlockers(GameObject[] gameObjects){
        foreach (GameObject item in gameObjects)
        {
            Rectangle intersection = Rectangle.Intersect(_bounds, item.Bounds);
            if(intersection.Width > 0){
                if((_previousBounds.X + _bounds.Width <= item.X) || (_previousBounds.X >= item.X + item.Bounds.Width)){
                    _bounds.X = _previousBounds.X;
                }
            }
            if(intersection.Height > 0){
                if((_previousBounds.Y + _bounds.Height <= item.Y) || (_previousBounds.Y >= item.Y + item.Bounds.Height)){
                    _bounds.Y = _previousBounds.Y;
                    _speedY = 0;
                }
            }
        }
    }
}