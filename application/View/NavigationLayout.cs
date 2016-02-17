using System.Windows;
using System.Windows.Controls;

namespace application.View
{
    public struct ButtonsLayout
    {
        public bool[] ButtonActives;
        public string[] ButtonContents;
        public ButtonPosition[] ButtonPositions;
        public HorizontalAlignment[] ButtonAlignments;
    }
    public struct ButtonPosition
    {
        public int Colum;
        public int Row;
    }

    public class NavigationLayout
    {
        public NavigationLayout(Grid listViewGrid)
        {
            _listViewGrid = listViewGrid;
            _buttons = new Button[ButtonCount];
            for (var i = 0; i < ButtonCount; i++)
            {
                _buttons[i] = new Button() { Margin = new Thickness(5) };
            }

       }

        public void DrowButtons(ButtonsLayout buttonsLayout)
        {
            for (var i = 0; i < ButtonCount; i++)
            {
                if (!buttonsLayout.ButtonActives[i]) continue;
                _buttons[i].Content = buttonsLayout.ButtonContents[i];
                _listViewGrid.Children.Add(_buttons[i]);
                Grid.SetColumn(_buttons[i], buttonsLayout.ButtonPositions[i].Colum);
                Grid.SetRow(_buttons[i], buttonsLayout.ButtonPositions[i].Row);

            }
        }
        //Количество новигационных конопок
        public static int ButtonCount = 6;
        private readonly Grid _listViewGrid;
        private readonly Button[] _buttons;
    }
}
