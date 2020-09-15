public class PlayerStateDoubleJump : FSMState<Player>
{
    public override string Name
    {
        get { return "DoubleJump"; }
    }

    public override void OnStateEntered(Player player)
    {
        player.CalculateJump();
    }

    public override string OnStateProcess(float delta, Player player)
    {
        player.CalculateGravity();
        player.CalculateHorizontalMovement();

        if (player.IsOnFloor())
            return "Run";
        if (player.IsCastingOnWall())
            return "WallSlide";

        return Name;
    }
}
