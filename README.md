# unity-tween

## What is it?
A simple to use tween library, for moving things with code

## What are the requirements?
 * Unity 2018.x

## How to use it

### Creating Tweens
There are a lot of ways to create tweens, the 2 primary ways are

#### Using Constructors:
```c#
// animation position using a MoveAnimation
var animation = new MoveAnimation(targetObject, from, to, duration, easing);
```

#### Using extension methods
```c#
// This is just shorthand for the above
var animation = myTransform.Move(from, to, duration, easing);
```

Although there are a lot of these, the function signatures are usually similar

| Name           | Description  |
| -------------- | -------------|
| `target`       | The object that the tween will affect |
| `from`         | the initial state (could be position, rotation, scale, opacity, color etc |
| `to`           | the final state (will be the same type as `from`|
| `duration`     | The duration in seconds of how long the tween will take to complete, defaults to `1.0f` |
| `easing`       | The type of easing to apply, defaults to `Linear`, please see [easing](#easing) for more info |
| `localSpace`   | (only on some functions), a boolean to control whether or not to use local space, for moving and rotation. |

#### Delegate Animations
Sometimes you don't always know the `from` parameter at the time you create the tween. You only know that at the time we want to play the tween. Delegate animations are used to acheive this.

A delegate animation takes a function that returns an animation. It won't get called until it is played.
```c#
var animation = new DelegateAnimation<MoveAnimation>(() => {
  return new MoveAnimation(target, target.position, finalPosition);
});
``` 

This allows you to not worry about the starting state, just care about where it should go to.

Several extensions exist to do this for you. `MoveTo`, `ScaleTo` `FadeTo` etc. all just make a delegate animation so at play time, the from will be the current state it's in.

#### Easing

### Playing Tweens
**Examples of play**
**Show callbacks**

### TweenCollections
**Sequences**
**Parallel**
**Extension Methods**

### Advanced playback features
**Repeat Count**
**Reverse** 
**Change Speed**
**Scale Time**

### AnimationDrivers
**Animation Driver**
