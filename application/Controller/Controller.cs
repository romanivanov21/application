using application.Interface;
using application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace application.Controller
{
    class Controller
    {
        #region Конструктор 

        public Controller(IView view, IViewFind viewFind)
        {
            #region Инициализация модели

            model_ = new ModelTest();
            model_.FillTestData();

            #endregion

            #region Интерфейс IView

            view_ = view;
            view_.ListViewUpdate(model_.GetThreeLastEntryes());
            view_.mainListVliewSelectionChanged += MainListVliewSelectionChanged;

            #endregion

            #region Интерфейс IViewFind

            viewFind_ = viewFind;
            viewFind_.dateFindRadioChecked += DateFindRadioChecked;
            viewFind_.descriptionFindRadioChecked += DescriptionFindRadioChecked;
            viewFind_.findBoxsGotKeyboardFocus += FindBoxsGotKeyboardFocus;
            viewFind_.findButtonClick += FindButtonClick;
            viewFind_.mainCalendarSelectedDatesChanged += MainCalendarSelectedDatesChanged;

            #endregion
        }

        #endregion

        #region Реализация методов IView

        public void MainListVliewSelectionChanged(object sender, EventArgs e)
        {   //Надо реализовать в view
            MessageBox.Show("Выбран запись № " + view_.GetMainListView().SelectedIndex);
        }

        #endregion

        #region Реализация методов IViewFind

        public void DateFindRadioChecked(object sender, EventArgs e)
        {
            if (viewFind_.GetSelectedMainCalendarDate() != null)
            {
                viewFind_.FindBoxSetText(viewFind_.GetSelectedMainCalendarDate());
            }
            else
            {
                viewFind_.FindBoxSetText("Поиск по дате");
            }
        }

        public void DescriptionFindRadioChecked(object sender, EventArgs e)
        {
            viewFind_.FindBoxSetText("Поиск по описанию");
        }

        public void FindBoxsGotKeyboardFocus(object sender, EventArgs e)
        {
            viewFind_.FindBoxSetText("");
        }

        private void FindButtonClick(object sender, EventArgs e)
        {
            string findBoxText = viewFind_.GetFindBoxText();
            #warning: TDDO:Проверка данных на вилидность
            if ((findBoxText == "") || (findBoxText == "Поиск") || (findBoxText == "Поиск по дате") || (findBoxText == "Поиск по описанию"))
            {
                MessageBox.Show("Введите параметры поиска");
            }
            else if(viewFind_.GetSelectedMainCalendarDate() == viewFind_.GetFindBoxText())
            {
                view_.ListViewUpdate(model_.GetEnrtyesByDate(viewFind_.GetFindBoxText()));
            }
        }

        private void MainCalendarSelectedDatesChanged(object sender, EventArgs e)
        {
            if (viewFind_.isDateFindRadiEnabeled())
            {
                viewFind_.FindBoxSetText(viewFind_.GetSelectedMainCalendarDate());
            }    
        }
        
        #endregion

        private ModelTest model_;
        private IView view_;
        private IViewFind viewFind_;

    }
}
