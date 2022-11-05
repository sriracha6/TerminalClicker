using System;

namespace Renderer
{
    public class HorizontalScrollBar : IInteractive
    {
        Vector2 _Position;
        public Vector2 Position { get { return _Position; } set { if(_Position != null) DeRender(); _Position = value; } }
        int _Progress;
        public int Progress { get { return _Progress; } set { _Progress = value; ReRender(); } }
        int _width;
        public int Width { get { return _width; } set { _width = value; if(_Position != null) ReRender(); } }

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
        
        char sliderChar = '-';
        char ends = '#';
        char noProgress = ' ';

        int previousString;

        public HorizontalScrollBar(int progress, int width)
        {
            this._Progress = progress;
            this.Width = width;
        }

        public HorizontalScrollBar(int progress, int width, char sliderChar, char ends, char noProgress)
        {
            this._Progress = progress;
            this.sliderChar = sliderChar;
            this.ends = ends;
            this.Width = width;
            this.noProgress = noProgress;
        }

        public void Render()
        {
            //if(Selected) Console.BackgroundColor = Window.SelectedColor;
            UIElement.Write(ends);
            for(int i = 0; i < Width; i++)
            {
                if (Progress == 0 && i == 1)
                    UIElement.Write(sliderChar);
                else if (i == Progress && i != 0)
                    UIElement.Write(sliderChar);
                else
                    UIElement.Write(noProgress);
                UIElement.CursorPos(Position.x+i+1, Position.y);
                previousString++;
            }
            UIElement.Write(ends);
            //if(Selected) Console.BackgroundColor = ConsoleColor.Black;
        }

        public void DeRender()
        {
            UIElement.CursorPos(Position.x, Position.y);
            UIElement.Write(new string(' ', previousString));
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
        public void OnUpArrow() { }
        public void OnDownArrow() { }
        public void OnLeftArrow() 
        {
            if(Progress > 0)
                Progress--;
            ReRender();
        }
        public void OnRightArrow() 
        {
            if(Progress < Width-1)
                Progress++;
            ReRender();
        }
        public void OnHoverLeave() { }

        public void OnTextInput(ConsoleKeyInfo character) { }
    }
}