using System.Collections.Generic;
using System.Drawing;

class BoxFactory
{
    public List<BoxDescription> Descriptions { get; set; }
    private static BoxFactory Instance { get; set; }

    private BoxFactory() {
        Descriptions = new List<BoxDescription>();
    }

    // Search if these is a BoxDescription has the same parameters and return it,
    // if not, create new one, add it to the list and return it.
    public BoxDescription GetBoxDescription(string backImage, Size size) {
        BoxDescription description = null;

        Descriptions.ForEach(x => {
            if (x.BackImage == backImage && x.Size == size)
                description = x;
        });

        if (description == null) {
            description = new BoxDescription {BackImage=backImage, Size=size};
        }
        
        return description;
    }

    public static BoxFactory GetInstance() => Instance == null ? new BoxFactory() : Instance;
}