using System;

public class FSM<Context>
{
    public FSMState<Context>[] states;
    public Context context;
    public FSMState<Context> state;
    public FSMState<Context> previousState;
    public bool justTransitioned = true;

    public FSM(FSMState<Context>[] states, Context context)
    {
        this.states = states;
        this.context = context;
        this.state = states[0];
        this.previousState = null;
        this.justTransitioned = true;
    }

    public void Process(float delta)
    {
        if (justTransitioned)
            state.OnStateEntered(this.context);
        string nextStateName = state.OnStateProcess(delta, this.context);
        UpdateState(nextStateName);
    }

    private void UpdateState(string nextStateName)
    {
        FSMState<Context> nextState = Array.Find(states, x => x.Name == nextStateName);

        if (nextState == null)
            throw new Exception("State does not exist");

        justTransitioned = state != nextState;
        previousState = state;
        state = nextState;
    }
}
