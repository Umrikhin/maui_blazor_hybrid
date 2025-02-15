namespace HybridTodoApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Родной интерфейс", "Эта кнопка из нативного интерфейса", "Ok");
        }
    }
}
