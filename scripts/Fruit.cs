using Godot;
using System;

public class Fruit : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private AnimatedSprite animatedSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

        Connect("body_entered", this, "onFruitBodyEntered");

        string[] fruitAnimations = new string[] {
            "Apple",
            "Banana",
            "Cherry",
            "Kiwi",
            "Melon",
            "Orange",
            "Pineapple",
            "Strawberry"
        };
        var random = new Random();
        var randomIndex = random.Next(fruitAnimations.Length);

        animatedSprite.Play(fruitAnimations[randomIndex]);
    }

    async public void onFruitBodyEntered(Node body)
    {
        animatedSprite.Play("Collected");
        GetTree().CallGroup("HUD", "OnFruitCollected");
        await ToSignal(animatedSprite, "animation_finished");
        QueueFree();
    }
}
