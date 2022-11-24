using RecepieMauiSQLite.Models;

namespace RecepieMauiSQLite.Views;

public partial class RecepieListPage : ContentPage
{
	public RecepieListPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        List<RecepieModel> recepies = await App.DataRepo.GetAllRecepies();
        statusMessage.Text = "";
        recepielist.ItemsSource = recepies;
        //emoji = recepies.ElementAt<Emoji>;
    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null)
        {
            // Navigate to the NoteEntryPage, passing the ID as a query parameter.
            RecepieModel rec = (RecepieModel)e.CurrentSelection.FirstOrDefault();
            await Shell.Current.GoToAsync($"{nameof(AddItemPage)}?{nameof(AddItemPage.currentId)}={rec.Id.ToString()}");
        }
    }

    private async void AddNew(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddItemPage));

    }

    private async void DeleteNoteAsync(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddItemPage));
    }

  
}