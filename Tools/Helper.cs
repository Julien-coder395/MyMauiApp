using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.Tools
{
    public class Helper
    {
        public static bool HasLogin =>
            !string.IsNullOrEmpty(SecureStorage.Default.GetAsync("oauth_token").GetAwaiter().GetResult());
    }
}
