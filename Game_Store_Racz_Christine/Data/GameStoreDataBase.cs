using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game_Store_Racz_Christine.Models;
namespace Game_Store_Racz_Christine.Data
{
    public class GameStoreDataBase
    {
        readonly SQLiteAsyncConnection _database;
        public GameStoreDataBase(string dbPath)
        {
            
            _database = new SQLiteAsyncConnection(dbPath);//creates a new sqlite connection
            _database.CreateTableAsync<User>().Wait(); 
            _database.CreateTableAsync<Game>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            

        }
       
        public Task<User> GetUserAsync(string email, string password)
        {
            return _database.Table<User>() //it returns the user from the database that maches the email and the password given
            .Where(i => i.Email == email && i.Password==password)
           .FirstOrDefaultAsync(); //return the first element or null if nothing is found
        }

        public Task<User> GetUserAsync(string email)
        {
            return _database.Table<User>()
            .Where(i => i.Email == email) //the same as above but it looks only for a maching email in the database
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveUpdateUserAsync(User sUser)
        {
            if (sUser.ID != 0)
            {
                return _database.UpdateAsync(sUser); 
            }
            else
            {
                return _database.InsertAsync(sUser);
            }
        }
        public Task<int> DeleteUserAsync(User sUser)
        {
            return _database.DeleteAsync(sUser); //deletes the user
        }
        public Task<int> SaveCategoryAsync(Category scat)
        {
            if (scat.ID != 0)
            {
                return _database.UpdateAsync(scat);
            }
            else
            {
                return _database.InsertAsync(scat);
            }
        }

        public Task<List<Category>> GetCategorysAsync()
        {
            return _database.Table<Category>().ToListAsync();
        }
        public Task<int> SaveGameAsync(Game sgame)
        {
            if (sgame.ID != 0)
            {
                return _database.UpdateAsync(sgame);
            }
            else
            {
                return _database.InsertAsync(sgame);
            }
        }
        public Task<int> DeleteGameAsync(Game sgame)
        {
            return _database.DeleteAsync(sgame);
        }
        public Task<List<Game>> GetGamesAsync()
        {
            return _database.Table<Game>().ToListAsync();
        }

        public Task<List<Game>> GetGamesAsync(int UserID)
        {
            return _database.QueryAsync<Game>(
            "select G.ID, G.Description, G.Name, G.ReleaseDate from Game G"
            + " inner join Category C"
            + " on C.ID = G.CategoryID where G.UserID = ?", //???
            UserID);
        }
    }
}
