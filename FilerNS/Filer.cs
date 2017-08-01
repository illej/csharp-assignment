using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerNS
{
    public class Filer : IFiler
    {
        protected string Level { get; private set; }
        protected string RawString { get; private set; }
        protected string CompressedString { get; private set; }
        protected string DecompressedString { get; private set; }
        public string Load(string filename)
        {
            Decompress();
            return DecompressedString;
        }

        public void Save(string filename, IFileable callMeBackforDetails)
        {
            StringBuilder builder = new StringBuilder();
            int rows = callMeBackforDetails.GetRowCount();
            int columns = callMeBackforDetails.GetColumnCount();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    char part = (char)callMeBackforDetails.WhatsAt(i, j);
                    builder.Append(part);
                }
                if (i < (rows - 1))
                {
                    builder.AppendLine();
                }
            }
            RawString = builder.ToString();
            Compress();
            System.IO.File.WriteAllText(filename, CompressedString);
        }

        public void SetString(string input)
        {
            RawString = input;
            Compress();
        }

        protected void Compress()
        {
            char[] chars = RawString.ToCharArray();
            StringBuilder builder = new StringBuilder();

            int count = 1;
            char previous = chars[0];
            for (int i = 1; i < chars.Length; i++)
            {
                char current = chars[i];
                if (current == previous)
                {
                    count++;
                }
                else
                {
                    if (count > 1)
                    {
                        builder.Append(count);
                    }
                    builder.Append(previous);
                    count = 1;
                }
                previous = current;
            }
            if (count > 1)
            {
                builder.Append(count);
            }
            CompressedString = builder.Append(previous).ToString();
        }

        protected void Decompress()
        {
            char[] chars = CompressedString.ToCharArray();
            StringBuilder builder = new StringBuilder();

            double count = 1;
            for (var i = 0; i < chars.Length; i++)
            {
                char current = chars[i];
                if (!char.IsNumber(current))
                {
                    for (var j = 0; j < count; j++)
                    {
                        builder.Append(current);
                    }
                    count = 1;
                }
                else
                {
                    count = char.GetNumericValue(current);
                }
            }
            DecompressedString = builder.ToString();
        }
    }
}
