using RecepieMauiSQLite.Models;

namespace RecepieMauiSQLite.Views
{
    [QueryProperty(nameof(currentId), nameof(currentId))]
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
            // Set the BindingContext of the page to a new Recepie.
            BindingContext = new RecepieModel();
        }
      
        public string currentId
        {
            set
            {
                LoadRecepie(value);
            }
        }
        async void LoadRecepie(string currentId)
        {
            try
            {
                int id = Convert.ToInt32(currentId);
                // Retrieve the note and set it as the BindingContext of the page.
                RecepieModel recObj = await App.DataRepo.GetRecepieByID(id);
                BindingContext = recObj;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        private async void SaveOnClick(object sender, EventArgs e)
        {
            var recepie = (RecepieModel)BindingContext;
         
            if (!string.IsNullOrWhiteSpace(recepie.Name))
            {
                await App.DataRepo.SaveorUpdate(recepie);
            }
            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        private async  void DelOnClick(object sender, EventArgs e)
        {
            var recepie = (RecepieModel)BindingContext;
            await App.DataRepo.DeleteNoteAsync(recepie);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}


