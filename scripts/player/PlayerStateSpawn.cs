public class PlayerStateSpawn : FSMState<Player>
{
    public override string Name
    {
        get { return "Spawn"; }
    }

    public override string OnStateProcess(float delta, Player player)
    {
        if (player.animatedSprite.Frame == 6)
            return "Idle";

        return Name;
    }
}
