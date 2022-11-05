using System;

namespace Renderer
{
    public class VerticalScrollBar : IInteractive
    {
        Vector2 _Position;
        public Vector2 Position { get { return _Position; } set { if(_Position != null) DeRender(); _Position = value; } }
        int _Progress;
        public int Progress { get { return _Progress; } set { _Progress = value; if (_Position != null) ReRender(); } }
        public int Height;

                bool _Visible = true;
        public bool Selected { get; set; }
        public bool Visible 
        { 
            get { return _Visible; } 
            set 
            {
                _Visible = value;
                if (value)
                    Render();
                else
                    DeRender();
            } 
        }
        
        char sliderChar = '|';
        char ends = '#';
        char noProgress = ' ';

        int previousString;

        public VerticalScrollBar(int progress, int height)
        {
            this._Progress = progress;
            this.Height = height;
        }

        public VerticalScrollBar(int progress, int height, char sliderChar, char ends, char noProgress)
        {
            this._Progress = progress;
            this.sliderChar = sliderChar;
            this.ends = ends;
            this.Height = height;
            this.noProgress = noProgress;
        }

        public void Render()
        {
            //if(Selected) Console.BackgroundColor = Window.SelectedColor;
            UIElement.Write(ends);
            for(int i = 0; i < Height; i++)
            {
                if (Progress == 0 && i == 1)
                    UIElement.Write(sliderChar);
                else if (i == Progress && i != 0)
                    UIElement.Write(sliderChar);
                else
                    UIElement.Write(noProgress);
                UIElement.CursorPos(Position.x, Position.y+i+1);
                previousString++;
            }
            UIElement.Write(ends);
            //if(Selected) Console.BackgroundColor = ConsoleColor.Black; // i shouldve put this in inputsystem isntead of putting it in every file. too bad!
        }

        public void DeRender()
        {
            UIElement.CursorPos(Position.x, Position.y);
            for(int i = 0; i < previousString; i++)
            {
                UIElement.CursorPos(Position.x, Position.y+i+1);
                UIElement.Write(" ");
            }
            previousString = 0;
        }

        public void ReRender()
        {
            DeRender();
            UIElement.CursorPos(Position.x, Position.y);
            Render();
        }

        public void OnHover() { }
        public void OnClick() { }
        public void OnUpArrow() 
        {
            if(Progress > 0)
                Progress--;
            ReRender();
        }
        public void OnDownArrow() 
        {
            if(Progress < Height-1)
                Progress++;
            ReRender();
        }
        public void OnLeftArrow() { }
        public void OnRightArrow() { }
        public void OnHoverLeave() { }

        public void OnTextInput(ConsoleKeyInfo character) { }
    }
}