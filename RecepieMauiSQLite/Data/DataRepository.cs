using RecepieMauiSQLite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecepieMauiSQLite
{
    public class DataRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<RecepieModel>();

        }  

        public DataRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task<int> SaveorUpdate(RecepieModel rece)
        {
            if (rece.Id != 0)
            {
                // Update an existing note.
                return await conn.UpdateAsync(rece);
            }
            else
            {


                int result = 0;
                try
                {
                    result = await conn.InsertAsync(rece);
                    StatusMessage = string.Format("Records added", result);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add ", result, ex.Message);
                }
                return result;
            }


        }

        public async Task<List<RecepieModel>> GetAllRecepies()
        {
            try
            {
                await Init();
                return await conn.Table<RecepieModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<RecepieModel>();
        }

        public async Task<RecepieModel> GetRecepieByID(int id)
        {
            // Get a specific note.
            return await conn.Table<RecepieModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteNoteAsync(RecepieModel note)
        {
            // Delete a note.
            return  await conn.DeleteAsync(note);
        }

    }
}
