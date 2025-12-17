using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookies
{
    public enum FileFormat
    {
        Json,
        Txt
    }

    public static class Settings
    {
        public const string FileName = "cookies";

        public const FileFormat Format = FileFormat.Json;
    }
}
