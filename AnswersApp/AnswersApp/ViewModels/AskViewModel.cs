using AnswersApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AnswersApp.ViewModels
{
    public class AskViewModel : BaseViewModel
    {
        public Ask MyQuestion { get; set; }

        public AskViewModel()
        {
            MyQuestion = new Ask();
        }


        public async Task<ObservableCollection<Ask>> GetQlist()
        {
            if (IsBusy) 
                return null;
            else
            {
                IsBusy = true;
                try
                {
                    ObservableCollection<Ask> list = new ObservableCollection<Ask>();

                    list = await MyQuestion.GetQuestionListByUser();

                    if (list != null)
                    {
                        return list;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    IsBusy = false;
                }
            }

            
        }
    }
}
