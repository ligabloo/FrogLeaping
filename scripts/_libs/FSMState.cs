public abstract class FSMState<Context>
{
    public abstract string Name { get; }
    public virtual void OnStateEntered(Context context) { }
    public virtual string OnStateProcess(float delta, Context context)
    {
        return Name;
    }
}
