using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Model;

namespace ViewModel
{
    class ButtonList
    {
        public QuestionsAndAnswerOptions Questions { get; set; }
        public int CorrectAnswerINT { get; set; }
        public int MistekeAnswerINT { get; set; }
        public string  Question { get; set; }
        public string[] ContentButton { get; set; }
        public Button ButtonStart { get; set; }
        public bool NewQestion { get; set; }
        public string CorrectAnswer { get; set; }
        List<Button> ListButton = new List<Button>();
        public ButtonList(Button but) 
        {
            ButtonStart = but;
            ButtonStart.Content = "Next";
            ButtonStart.IsEnabled = false;
            ButtonStart.Background = Brushes.Green;
        }
        public void AddButtonList(Button button)
        {
            if (ListButton.Count == 0)
                ListButton.Add(button);
            else if(ListButton.Count != 5)
            {
                for (int i = 0; i <= ListButton.Count; i++)
                { 
                    if(ListButton.Count == 5)
                        break;
                    if (i == ListButton.Count)
                    {
                        ListButton.Add(button);
                        break;
                    }
                    if (ListButton[i] == button || ListButton.Count == 5)
                        break;
                   
                }
            }
            CheckToCoreectAnswer(button);
        }
        
        public void CheckToCoreectAnswer(Button but)
        {

            int i = 0;
            for (; i < ListButton.Count; i++)
            {
                if (but == ListButton[i])
                    break;
            }
            if (ListButton[i].Content.ToString() == CorrectAnswer)
            {
                ButtonStart.IsEnabled = true;
                if(ListButton[i].Background != Brushes.Green)
                    CorrectAnswerINT++;
                ListButton[i].Background = Brushes.Green;
            }
            else
            {
                if (ListButton[i].Background != Brushes.Red)
                    MistekeAnswerINT++;

                    ListButton[i].Background = Brushes.Red;
            }
        }
        /// <summary>
        ///  returns to its original state
        ///  and gets a list with content
        /// </summary>
        /// <param name="content"></param>
        public void ButtonIsDefault()
        {
            if (ListButton.Count < 5)
            {
                for (int i = 0; i < ListButton.Count; i++)
                {
                    ListButton[i].Background = Brushes.LightGray;
                   
                }
            }
            else
            {
                for (int i = 0; i < ListButton.Count; i++)
                {
                    ListButton[i].Background = Brushes.LightGray;
                    ListButton[i].Content = ContentButton[i];
                }
            }
        }
        public void NewRandomQuestion(int start = 0, int end = 5)
        {
            ButtonStart.IsEnabled = false;
            Questions.NewQuestionContext(start, end);
            ContentButton = Questions.ContentButton;
            CorrectAnswer = Questions.CorectAnswer;
            ButtonIsDefault();
            Question = Questions.Question;
        }

    }
}
