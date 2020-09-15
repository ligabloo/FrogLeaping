using Godot;
public class PlayerStateWallSlide : FSMState<Player>
{
    public override string Name
    {
        get { return "WallSlide"; }
    }

    public override string OnStateProcess(float delta, Player player)
    {
        if (player.movement.y < 0)
            player.CalculateGravity();
        else
            player.CalculateWallSlide();

        if (Input.IsActionJustPressed("game_jump"))
        {
            player.FlipDirection();
            return "Jump";
        }
        if (player.IsOnFloor())
            return "Run";
        if (!player.IsCastingOnWall())
        {
            player.FlipDirection();
            return "Fall";
        }



        return Name;
    }
}
