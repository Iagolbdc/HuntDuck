using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : GameObject{
    private const float SPEED_X = 200;
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
        _currentAnimationKey = "move_left"; // Defina a animação padrão
        _currentAnimation = _animations[_currentAnimationKey];
    }

    public Player(Texture2D image) : base(image){

    }

    public override void Initialize(){
        _bounds.X = 100;
        _bounds.Y = 100;
    }

    public override void Update(float deltaTime)
    {

        Console.WriteLine(_bounds.Y);

        UpdateAnimation(deltaTime);

        directionY = 0;

        //Console.WriteLine($"{_bounds.Y + _image.Height} || {Globals.SCREEN_HEIGHT}");

        if((Input.GetKey(Keys.W) || Input.GetKey(Keys.Up)) && _bounds.Y > 0.0f ){
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

        if((Input.GetKey(Keys.S) || Input.GetKey(Keys.Down)) && _bounds.Y < 330){
            directionY = 1.0f;
        }

        if(directionY != 0){
            _bounds.Y = _bounds.Y + (int)(directionY * SPEED_X * deltaTime);
        }

        if(_bounds.X + _image.Width > 800){
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