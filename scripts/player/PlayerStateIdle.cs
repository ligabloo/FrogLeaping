public class PlayerStateIdle : FSMState<Player>
{
    public override string Name
    {
        get { return "Idle"; }
    }

    public override string OnStateProcess(float delta, Player player)
    {
        player.CalculateGravity();

        if (player.IsOnFloor())
            return "Run";

        return Name;
    }
}
