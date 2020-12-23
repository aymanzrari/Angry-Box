abstract class Component
{
    public virtual void Draw() {
        
    }

    public virtual Component Clone() {
        return this;
    }
}