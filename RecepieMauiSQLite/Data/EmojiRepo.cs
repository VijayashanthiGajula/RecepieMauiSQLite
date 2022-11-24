using RecepieMauiSQLite.Models;
using RecepieMauiSQLite.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecepieMauiSQLite.Data
{
    public class EmojiRepo : IEmoji
    {
        public Task<Stream> GetImageStreamAsync()
        {
            throw new NotImplementedException();
        }
    }
}
