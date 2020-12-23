class BoxState
{
    public States State { get; set; }

    public BoxState()
    {
        State = States.TAIL;
    }

    // Change the state of the box to turn it face or tail if the player triggered it.
    public void Turn() {
        if (State == States.FACE)
            State = States.TAIL;
        else
            State = States.FACE;
    }
}