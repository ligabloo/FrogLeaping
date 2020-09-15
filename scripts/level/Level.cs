using Godot;

public class Level : Node
{
    public override void _Ready()
    {
        AddToGroup("Level");
    }

    private void OnReload()
    {
        GetTree().ReloadCurrentScene();
    }
}
