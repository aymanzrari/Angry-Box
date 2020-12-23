class GameController
{
    private static GameController Instance { get; set; }
    public Grid Grid { get; set; }
    int position1 { get; set; }
    int position2 { get; set; }
    public int Selected { get; set; }

    private GameController() {
        Grid = new Grid();
        Selected = 0;
    }

    // If all the boxes are disabled then the player has won.
    public bool CheckWin() {
        bool flag = true;
        Grid.Boxes.ForEach(x => {
            if (x.IsEnabled == true) {
                flag = false;
                return;
            }
        });
        return flag;
    }

    // Play a turn, if the player has chosen the same objects, disable them and return some bonus.
    public int Play(int postition) {
        if (!Grid.Boxes[postition - 1].IsEnabled)
            return -1;

        Selected++;
        if (Selected == 1)
        {
            if (position2 != 0)
            {
                Grid.Boxes[position1 - 1].Turn();
                Grid.Boxes[position2 - 1].Turn();
            }

            position1 = postition;
        }
        else if (Selected == 2) {
            position2 = postition;
            if (ProjetPictue.Program.PositionPhotos[position1 - 1] == ProjetPictue.Program.PositionPhotos[position2 - 1]) {
                Grid.Boxes[position1 - 1].IsEnabled = false;
                Grid.Boxes[position2 - 1].IsEnabled = false;
                Selected = 0;
                return 10;
            }
            Selected = 0;
        }
        return 0;
    }

    public static GameController GetInstance()
    {
        if (Instance == null)
        {
            Instance = new GameController();
        }

        return Instance;
    }
}