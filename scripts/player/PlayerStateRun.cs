using Godot;

public class PlayerStateRun : FSMState<Player>
{
    public override string Name
    {
        get { return "Run"; }
    }

    public override void OnStateEntered(Player player)
    {
        if (player.direction.x == 0)
            player.direction.x = 1;
    }

    public override string OnStateProcess(float delta, Player player)
    {
        if (player.IsCastingOnWall())
            player.FlipDirection();

        player.CalculateGravity();
        player.CalculateHorizontalMovement();

        if (player.movement.y < 0)
            return "Fall";

        if (Input.IsActionJustPressed("game_jump"))
            return "Jump";

        return Name;
    }
}
