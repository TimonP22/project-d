using SQLite;
using project_d.Objects;

namespace project_d;

public class DatabaseHelper
{
    string _dbPath;
    private SQLiteAsyncConnection conn;

    private async Task Init()
    {
        if (conn != null) return;

        conn = new(_dbPath);
        await conn.CreateTableAsync<Psycholoog>();
        await conn.CreateTableAsync<Client>();
    }

    public DatabaseHelper(string dbPath)
    {
        _dbPath = dbPath;
    }

    public async Task AddNewUser(User user, Page page)
    {
        try
        {
            await Init();

            User existingUser;
            if (user is Psycholoog)
            {
                existingUser = await conn.Table<Psycholoog>().FirstOrDefaultAsync(u => u.Email == user.Email);
            }
            else
            {
                existingUser = await conn.Table<Client>().FirstOrDefaultAsync(u => u.Email == user.Email);
            }
            if (existingUser != null)
            {
                await page.DisplayAlert("Error", "Dit e-mailadres is al in gebruik.","OK");
                return;
            }
            await conn.InsertAsync(user);
            await page.DisplayAlert("Registreren", "Registratie succesvol.\nU kunt nu inloggen.", "OK");
            await page.Navigation.PushAsync(new MainPage());
        }
        catch (Exception ex)
        {
            await page.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    public async Task LogIn(Page page, string email, string password)
    {
        try
        {
            await Init();

            var user = await conn.Table<Psycholoog>().FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
            if (user == null)
            {
                await page.DisplayAlert("Inloggen", "Gebruiker niet gevonden.", "OK");
                return;
            }

            Helper.User = user;
            await page.Navigation.PushAsync(new StartschermPsycholoog(), true);
        }
        catch (Exception ex)
        {
            await page.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
