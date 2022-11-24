using RecepieMauiSQLite.Views;

namespace RecepieMauiSQLite;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(AddItemPage), typeof(AddItemPage));
    }
}
