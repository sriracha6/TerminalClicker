using System;
using Renderer;
using TerminalClicker;

namespace TerminalEngine
{
    public class Program
    {
        public static void Main()
        {
            Window.Init(120,30,ConsoleColor.DarkBlue,750);
            BigTextBox btbintro = new BigTextBox("(Use tab, shift-tab, enter, and arrow keys to control the UI) You are a developer. A solo developer. In this world, that can mean only one thing: you need ego points. You will remake things that have already been made to flex. Your name is John. I am your father. Your father before me did the same as I did. Good luck, my son.", 119, 29);
            Button continueButton = new Button("Continue");
            continueButton.onClick = () => { btbintro.Visible = false; continueButton.Visible = false; DisplayMainArea(); };
            URenderer.Render(btbintro, new Vector2(0,0));
            URenderer.Render(continueButton, new Vector2(50,29));
        }

        public static void DisplayMainArea()
        {
            Console.Clear();
            SaveProgress.Save();
        }
    }
}