using application.Interface;
using application.Model;
using System;
using System.Windows;

namespace application.Controller
{
    internal class MainController
    {
        #region Конструктор 

        public MainController(IView view, IViewFind viewFind)
        {
            #region Инициализация модели

            _model = new ModelTest();
            _model.FillTestData();

            #endregion

            #region Интерфейс IView

            _view = view;
            _view.ListViewUpdate(_model.GetThreeLastEntryes());
            _view.MainListVliewSelectionChanged += MainListVliewSelectionChanged;

            #endregion

            #region Интерфейс IViewFind

            _viewFind = viewFind;
            _viewFind.dateFindRadioChecked += DateFindRadioChecked;
            _viewFind.descriptionFindRadioChecked += DescriptionFindRadioChecked;
            _viewFind.findBoxsGotKeyboardFocus += FindBoxsGotKeyboardFocus;
            _viewFind.findButtonClick += FindButtonClick;
            _viewFind.mainCalendarSelectedDatesChanged += MainCalendarSelectedDatesChanged;

            #endregion
        }

        #endregion

        #region Реализация методов IView

        public void MainListVliewSelectionChanged(object sender, EventArgs e)
        {   //Надо реализовать в view
            MessageBox.Show("Выбран запись № " + _view.GetMainListView().SelectedIndex);
        }

        #endregion

        #region Реализация методов IViewFind

        public void DateFindRadioChecked(object sender, EventArgs e)
        {
            if (_viewFind.GetSelectedMainCalendarDate() != null)
            {
                _viewFind.FindBoxSetText(_viewFind.GetSelectedMainCalendarDate());
            }
            else
            {
                _viewFind.FindBoxSetText("Поиск по дате");
            }
        }

        public void DescriptionFindRadioChecked(object sender, EventArgs e)
        {
            _viewFind.FindBoxSetText("Поиск по описанию");
        }

        public void FindBoxsGotKeyboardFocus(object sender, EventArgs e)
        {
            _viewFind.FindBoxSetText("");
        }

        private void FindButtonClick(object sender, EventArgs e)
        {
            var findBoxText = _viewFind.GetFindBoxText();
            if ((findBoxText == "") || (findBoxText == "Поиск") || (findBoxText == "Поиск по дате") || (findBoxText == "Поиск по описанию"))
            {
                MessageBox.Show("Введите параметры поиска");
            }
            else if(_viewFind.GetSelectedMainCalendarDate() == _viewFind.GetFindBoxText())
            {
                _view.ListViewUpdate(_model.GetEnrtyesByDate(_viewFind.GetFindBoxText()));
            }
        }

        private void MainCalendarSelectedDatesChanged(object sender, EventArgs e)
        {
            if (_viewFind.isDateFindRadiEnabeled())
            {
                _viewFind.FindBoxSetText(_viewFind.GetSelectedMainCalendarDate());
            }    
        }
        
        #endregion

        private readonly ModelTest _model;
        private readonly IView _view;
        private readonly IViewFind _viewFind;
    }
}
