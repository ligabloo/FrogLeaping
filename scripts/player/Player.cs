using Godot;

public class Player : KinematicBody2D
{
    // State Machine
    private FSM<Player> machine;

    // Nodes
    public AnimatedSprite animatedSprite;
    public RayCast2D handRayCast;
    public RayCast2D footRayCast;

    // Constants
    const float Gravity = 20f;
    const float MoveSpeed = 120f;

    const float JumpSpeed = 450f;
    const float WallSlideSpeed = MoveSpeed / 1.5f;

    // Properties
    public Vector2 direction;
    public Vector2 movement;

    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        handRayCast = GetNode<RayCast2D>("HandRayCast");
        footRayCast = GetNode<RayCast2D>("FootRayCast");

        machine = new FSM<Player>(new FSMState<Player>[] {
            new PlayerStateSpawn(),
            new PlayerStateIdle(),
            new PlayerStateRun(),
            new PlayerStateJump(),
            new PlayerStateFall(),
            new PlayerStateDoubleJump(),
            new PlayerStateWallSlide()
        }, this);
    }

    public override void _PhysicsProcess(float delta)
    {
        animatedSprite.Play(machine.state.Name);
        machine.Process(delta);
        ApplyMovement();
    }

    public void CalculateGravity()
    {
        movement.y += Gravity;
    }

    public void CalculateWallSlide()
    {
        movement.y = WallSlideSpeed;
    }

    public void CalculateHorizontalMovement()
    {
        movement.x = MoveSpeed * direction.x;
    }

    public void CalculateJump()
    {
        movement.y = -JumpSpeed;
    }

    public void ApplyMovement()
    {
        movement = MoveAndSlide(movement, Vector2.Up);
    }

    public void FlipDirection()
    {
        direction.x *= -1;
        handRayCast.CastTo *= -1;
        footRayCast.CastTo *= -1;
        animatedSprite.FlipH = direction.x < 0;
    }

    public bool IsCastingOnWall()
    {
        return handRayCast.IsColliding() || footRayCast.IsColliding();
    }

}
