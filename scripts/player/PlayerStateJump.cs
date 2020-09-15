using Godot;

public class PlayerStateJump : FSMState<Player>
{
    public override string Name
    {
        get { return "Jump"; }
    }

    public override void OnStateEntered(Player player)
    {
        player.CalculateJump();
    }

    public override string OnStateProcess(float delta, Player player)
    {
        player.CalculateGravity();
        player.CalculateHorizontalMovement();

        if (player.IsCastingOnWall())
            return "WallSlide";
        if (player.IsOnFloor())
            return "Run";
        if (player.movement.y > 0)
            return "Fall";
        if (Input.IsActionJustPressed("game_jump"))
            return "DoubleJump";

        return Name;
    }
}
