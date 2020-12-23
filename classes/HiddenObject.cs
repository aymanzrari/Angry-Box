class HiddenObject
{
    public string Image { get; set; }

    public override bool Equals(object obj)
    {
        if (!(obj is HiddenObject))
            return false;
        else if (((HiddenObject)obj).Image == Image)
            return true;
        
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}