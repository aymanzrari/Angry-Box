using System.Drawing;
using System.Windows.Forms;

class ImageBinder : IBinder
{
    public void BindImage(PictureBox pictureBox, string photo)
    {
        pictureBox.Image = Image.FromFile(photo);

        System.GC.Collect();
    }
}