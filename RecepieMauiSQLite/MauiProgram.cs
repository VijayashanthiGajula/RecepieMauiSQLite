using Microsoft.Extensions.Logging;
using RecepieMauiSQLite.Views;

namespace RecepieMauiSQLite;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        string dbPath = FileAccessHelper.GetLocalFilePath("RecepieDB.db3");
        builder.Services.AddSingleton<DataRepository>
			(s => ActivatorUtilities.CreateInstance<DataRepository>(s, dbPath));

        //services
        

        //Views Registration
       // builder.Services.AddSingleton<ReceipeList>();
        builder.Services.AddSingleton<AddItemPage>();

        //View Models
        //builder.Services.AddSingleton<RecepieListVM>();
       // builder.Services.AddTransient<AddOrUpdateRecepieVM>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
