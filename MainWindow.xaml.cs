using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P30_Querst_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();
            }

            private void SubmitButton_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    string surveyResults = GetSurveyResults();
                    SendEmail(surveyResults);
                    MessageBox.Show("Ответы успешно отправлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при отправке: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            private string GetSurveyResults()
            {
                var results = QuestionsItemsControl.Items.Cast<QuestionModel>()
                    .Select(q => $"{q.QuestionType}: {string.Join(", ", q.Votes)}")
                    .ToList();

                return string.Join("\n", results);
            }

            private void SendEmail(string body)
            {
                string fromEmail = "test@example.com";
                string toEmail = "survey@example.com";
                string subject = "Результаты опроса";

                MessageBox.Show($"Отправка письма:\nОт: {fromEmail}\nКому: {toEmail}\nТема: {subject}\n\n{body}");
            }
        }
    }
    public class QuestionModel
    {
        public string QuestionType { get; set; }
        public string[] Votes { get; set; }
    }
}

