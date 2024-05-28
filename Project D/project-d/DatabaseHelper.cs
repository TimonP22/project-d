using SQLite;
using project_d.Objects;

namespace project_d;

public class DatabaseHelper
{
    string _dbPath;
    private SQLiteAsyncConnection conn;

    private async Task Init(bool clear=false)
    {
        if (conn != null) return;

        conn = new(_dbPath);
        if (clear)
        {
            await conn.DropTableAsync<Psycholoog>();
            await conn.DropTableAsync<Client>();
            await conn.DropTableAsync<Huiswerk>();
        }
        await conn.CreateTableAsync<Psycholoog>();
        await conn.CreateTableAsync<Client>();
        await conn.CreateTableAsync<Huiswerk>();
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
            User user;
            if (Helper.IsPsychologist)
                user = await conn.Table<Psycholoog>().FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
            else
                user = await conn.Table<Client>().FirstOrDefaultAsync(p => p.Email == email && p.Password == password);

            if (user == null)
            {
                await page.DisplayAlert("Inloggen", "Gebruiker niet gevonden.", "OK");
                return;
            }

            Helper.User = user;

            if (Helper.IsPsychologist)
            {
                await GetClients((Psycholoog)user);
                await page.Navigation.PushAsync(new StartschermPsycholoog(), true);
            }
            else
                await page.DisplayAlert("Inloggen", "Cliëntpagina's nog niet geïmplementeerd.", "OK");
        }
        catch (Exception ex)
        {
            await page.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    public async Task FillDataBase(Page page)
    {
        List<User> users = new()
        {
            new Psycholoog("Mark", "Koopmans", new DateTime(1987, 1, 1), "mkoopmans@pd.nl", "mkpd"),
            new Client("Kees", "Janssen", new DateTime(1995, 1, 1), "kjanssen@gmail.com", "kjpd", 1),
            new Client("Gerard", "Spijkerman", new DateTime(1999, 1, 1), "gspijkerman@gmail.com", "gspd", 1),
            new Client("Armando", "Bieleveld", new DateTime(1995, 1, 1), "abieleveld@gmail.com", "abpd", 1),
            new Client("Catlijn", "Verheul", new DateTime(2005, 1, 1), "cverheul@gmail.com", "cvpd", 1),
        };

        try
        {
            await Init(true);
            await conn.InsertAllAsync(users);
            await page.DisplayAlert("Notification", "Database has been filled for testing", "OK");
        }
        catch (Exception ex)
        {
            await page.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    public async Task GetClients(Psycholoog psycholoog)
    {
        try
        {
            await Init();
            psycholoog.Clients = await conn.Table<Client>().Where(c => c.PsychologistId == psycholoog.Id).ToListAsync();
        }
        catch
        {
        }
    }

    public async Task GetHomework(Client client)
    {
        try
        {
            await Init();
            client.Huiswerk = await conn.Table<Huiswerk>().Where(h => h.ClientId == client.Id).ToListAsync();
        }
        catch
        {
        }
    }

    public async Task PublishHomework(Huiswerk huiswerk)
    {
        try
        {
            await Init();
            await conn.InsertAsync(huiswerk);
        }
        catch
        {
        }
    }

    public async Task ClearDatabase(Page page)
    {
        await Init(true);

        await page.DisplayAlert("Notification", "Database has been reset", "OK");
    }
}
