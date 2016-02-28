using System;

namespace application.Interface
{
    internal interface INavigationButtonsClick
    {
        event EventHandler FourClick;
        event EventHandler NextClick;
        event EventHandler OneClick;
        event EventHandler PrevClick;
        event EventHandler ThreClick;
        event EventHandler TwoClick;
    }
}
