using application.Interface;
using application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Controller
{
    class Controller
    {
        public Controller(IView view)
        {
            model_ = new ModelTest();
            model_.FillTestData();
            view_interface_ = view;
            view_interface_.WindowInit(model_.EntryesList);
        }

        private ModelTest model_;
        private IView view_interface_;
    }
}
