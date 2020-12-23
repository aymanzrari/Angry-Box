using System.Drawing;
using System.Windows.Forms;
class Box: Component, IBinder
{
    public BoxDescription Description { get; set; }
    public HiddenObject HiddenObject { get; set; }
    public BoxState State { get; set; }
    public ImageBinder ImageBinder { get; set; }
    public BoxFactory BoxFactory { get; set; }
    public PictureBox PictureBox { get; set; }
    public string CurrentImage { get; set; }
    public int Position { get; set; }
    public bool IsEnabled { get; set; }

    // Draw this Box to the game panel
    public override void Draw() {
        PictureBox = new PictureBox();
        PictureBox.Size = new Size(79, 66);
        PictureBox.Image = Image.FromFile(Description.BackImage);
        PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        ProjetPictue.Program.FlowLayoutPanel.Controls.Add(PictureBox);
        HiddenObject.Image = "images/" + ProjetPictue.Program.PositionPhotos[Position - 1] + ".jpg";
        CurrentImage = "images/"+ ProjetPictue.Program.PositionPhotos[Position - 1] +".jpg";

        PictureBox.Click += (x, ex) =>
        {
            Turn();
            //MessageBox.Show(Position.ToString());
            GameEngine gameEngine = GameEngine.GetInstance();
            gameEngine.Play(Position);
        };
    }

    // Get an exact same object as this one.
    public override Component Clone() {
        BoxDescription boxDescription = BoxFactory.GetBoxDescription(Description.BackImage, Description.Size);
        HiddenObject hiddenObject = new HiddenObject{Image=HiddenObject.Image};
        BoxState boxState = new BoxState{State=State.State};
        ImageBinder imageBinder = new ImageBinder();
        BoxFactory boxFactory = BoxFactory.GetInstance();
        string image = (string)CurrentImage.Clone();

        return new Box{Description=boxDescription, HiddenObject=hiddenObject, 
                        State=boxState, ImageBinder=imageBinder, 
                        BoxFactory=boxFactory, CurrentImage=image, Position=this.Position,
                        IsEnabled=this.IsEnabled};
    }

    // Change the box state, animate it and bind it's image if needed.
    public void Turn() {
        if (IsEnabled)
            State.Turn();

        if (State.State == States.FACE)
            BindImage(PictureBox, HiddenObject.Image);
        else
            BindImage(PictureBox, Description.BackImage);
    }

    public void BindImage(PictureBox pictureBox, string photo)
    {
        ImageBinder.BindImage(pictureBox, photo);
    }

    // Check if the boxes are the same.
    public override bool Equals(object obj) {
        if (!(obj is Box))
            return false;
        else if (((Box)obj).HiddenObject.Equals(this.HiddenObject))
            return true;
        return false;
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }
}