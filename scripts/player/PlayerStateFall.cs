using Godot;

public class PlayerStateFall : FSMState<Player>
{
    public override string Name
    {
        get { return "Fall"; }
    }

    public override string OnStateProcess(float delta, Player player)
    {
        player.CalculateGravity();

        if (player.IsOnFloor())
            return "Run";
        if (player.IsCastingOnWall())
            return "WallSlide";
        if (Input.IsActionJustPressed("game_jump"))
            return "DoubleJump";

        return Name;
    }
}
