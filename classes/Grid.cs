using System.Collections.Generic;

class Grid: Component
{
    public List<Box> Boxes { get; set; }

    public Grid()
    {
        Boxes = new List<Box>();
    }

    // Iterate over each box and draw it.
    public override void Draw() => Boxes.ForEach(x => x.Draw());

    // Get the same whole grid.
    public override Component Clone() {
        Grid grid = new Grid();
        Boxes.ForEach(x => grid.Add((Box)x.Clone()));
        return grid;
    }

    // Add box to the grid.
    public void Add(Box box) => Boxes.Add(box);

    // Remove box from the grid.
    public void Remove(Box box) => Boxes.Remove(box);
}