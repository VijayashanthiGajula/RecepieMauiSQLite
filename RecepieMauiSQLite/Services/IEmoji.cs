using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecepieMauiSQLite.Services
{
    public interface IEmoji
    {
        Task<Stream> GetImageStreamAsync();
    }
}
