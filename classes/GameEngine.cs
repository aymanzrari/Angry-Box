using System;
using System.Threading;

class GameEngine
{
    public TimeSpan Time { get; set; }
    public int HighScore { get; set; }
    public Player Player { get; set; }
    public GameController GameController { get; set; }
    private static GameEngine Instance { get; set; }
    private static System.Timers.Timer timer;

    private GameEngine() {
        NewGame();
    }

    public static GameEngine GetInstance() {
        if (Instance == null)
            Instance = new GameEngine();
        return Instance;
    }

    // Initialize a new game environment
    public void NewGame() {
        Time = TimeSpan.Zero;
        HighScore = 0;
        Player = new Player{Name="Player 1", Score=0};
        ProjetPictue.Program.GeneratePhotos();
        GameController = GameController.GetInstance();

        Box box = new Box
        {
            Position = 1,
            CurrentImage = "",
            State = new BoxState(),
            IsEnabled = true,
            ImageBinder = new ImageBinder(),
            Description = BoxFactory.GetInstance().GetBoxDescription("images/card2.png", new System.Drawing.Size(79, 66)),
            HiddenObject = new HiddenObject(),
            BoxFactory = BoxFactory.GetInstance()
        };

        GameController.Grid.Add(box);

        for (int i = 1; i < 5 * 8; i++)
        {
            Box box2 = (Box)box.Clone();
            box2.Position = i + 1;
            GameController.Grid.Add(box2);
        }

        GameController.Grid.Draw();

        ShowImages(null, null);
        timer = new System.Timers.Timer();
        timer.Interval = 5000;
        timer.Elapsed += ShowImages;
        timer.Start();
    }

    private void ShowImages(object o, EventArgs ev)
    {
        GameController.Grid.Boxes.ForEach(e => e.Turn());
        if (timer != null)
            timer.Dispose();
    }

    // Try a box.
    public void Play(int postition) {
        int score = GameController.Play(postition);

        if (score != -1)
            Player.Score += score;

        bool isWinner = GameController.CheckWin();
        if (isWinner)
        {
            System.Windows.Forms.MessageBox.Show("You've won!! Your score is : " + Player.Score);
            ProjetPictue.Properties.Settings.Default.HighScore = Player.Score;
            ProjetPictue.Properties.Settings.Default.Save();
        }
    }
}