using System;

namespace DNA_Viz
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new DnaVisualiser())
                game.Run();
        }
    }
}
