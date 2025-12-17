using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesBook
{
    public enum FileFormat
    {
        Json,
        Txt
    }

    public static class Settings
    {
        public const string FileName = "recipes";

        public const FileFormat Format = FileFormat.Txt;

        public static string ToFilePath()
        {
            return $"{FileName}.{Format.GetExtension()}";
        }
    }

    public static class FileFormatHelper
    {
        public static string GetExtension(this FileFormat format)
        {
            return format == FileFormat.Json ? "json" : "txt";
        }
    }
}
