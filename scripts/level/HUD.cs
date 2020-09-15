using Godot;

public class HUD : Node
{
    private int fruits = 0;
    private Label fruitsLabel;
    private TextureButton reloadButton;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AddToGroup("HUD");

        fruitsLabel = GetNode<Label>("Container/Label");
        reloadButton = GetNode<TextureButton>("Container/ReloadButton");

        reloadButton.Connect("pressed", this, "OnReloadButtonPressed");
        UpdateFruitsLabel();
    }

    public void OnFruitCollected()
    {
        fruits++;
        UpdateFruitsLabel();
    }

    private void UpdateFruitsLabel()
    {
        fruitsLabel.Text = fruits.ToString();
    }

    private void OnReloadButtonPressed()
    {
        GetTree().CallGroup("Level", "OnReload");
    }


}
