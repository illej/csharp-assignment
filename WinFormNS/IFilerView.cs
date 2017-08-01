using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormNS
{
    public interface IFilerView
    {
        void Start();
        void Stop();
        void Display<T>(T message);
        string[] Load();
        string Save();
    }
}
