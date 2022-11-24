namespace RecepieMauiSQLite;

public partial class App : Application
{
    public static DataRepository DataRepo { get; private set; }
    public App(DataRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
        DataRepo = repo;

    }

}
