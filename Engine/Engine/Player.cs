using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : GameObject{
    private const float SPEED_X = 200;
    private const float JUMP_VELOCITY = -5;
    private Rectangle _previousBounds;
    public float directionX = -1;
    public float directionY = 0;
    public bool animationDirection = true;
    public bool dead = true;

    private Dictionary<string, Texture2D[]> _animations;
    private Texture2D[] _currentAnimation;
    private string _currentAnimationKey;
    private int _currentFrame;
    private float _frameTime;
    private float _elapsedTime;


    public Player(Dictionary<string, Texture2D[]> animations) : base(animations.Values.First()[0]){
        _animations = animations;
        _currentAnimationKey = "idle"; // Defina a animação padrão
        _currentAnimation = _animations[_currentAnimationKey];
    }

    public Player(Texture2D image) : base(image){

    }

    public override void Initialize(){
        _bounds.X = 150;
        _bounds.Y = 347;
    }

    public override void Update(float deltaTime)
    {

        Console.WriteLine(directionY);

        UpdateAnimation(deltaTime);

        directionY = 0;

        _previousBounds = _bounds;

        //Console.WriteLine($"{_bounds.Y + _image.Height} || {Globals.SCREEN_HEIGHT}");

        if(Input.GetKey(Keys.W) && _bounds.Y > 0.0f ){
            directionY = -1.0f; 
        }

        if(directionY < 0 && animationDirection){
            _currentAnimationKey = "move_left_up";
        }else if(directionY < 0 && !animationDirection){
            _currentAnimationKey = "move_right_up";
        }else if(animationDirection){
            _currentAnimationKey = "move_left";
        }else{
             _currentAnimationKey = "move_right";
        }

        if(Input.GetKey(Keys.S) && _bounds.Y < Globals.SCREEN_HEIGHT - _image.Height){
            directionY = 1.0f;
        }

        if(directionY != 0){
            _bounds.Y = _bounds.Y + (int)(directionY * SPEED_X * deltaTime);
        }

        if(_bounds.X + _image.Width > Globals.SCREEN_WIDTH ){
            directionX = -1.0f;
            animationDirection = true;
        }
        
        if(_bounds.X < 0.0f){
            directionX = 1.0f;
            animationDirection = false;
        }

        if(directionX != 0){
            _bounds.X = _bounds.X + (int)(directionX * SPEED_X * deltaTime);
        }

        if (_animations.ContainsKey(_currentAnimationKey) && _currentAnimation != _animations[_currentAnimationKey])
        {
            _currentAnimation = _animations[_currentAnimationKey];
            _currentFrame = 0;
        }

        // _speedY = _speedY + (GRAVITY * deltaTime);
        // _bounds.Y = _bounds.Y + (int)_speedY;
    }

    private void UpdateAnimation(float deltaTime)
    {
        _elapsedTime += deltaTime;
        if (_elapsedTime  >= (_frameTime + 0.1))
        {
            _elapsedTime = 0f;
            _currentFrame = (_currentFrame + 1) % _currentAnimation.Length;
            _image = _currentAnimation[_currentFrame];
        }
    }
}