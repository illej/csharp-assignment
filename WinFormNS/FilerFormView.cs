using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormNS
{
    public partial class FilerFormView : WinFormNS.BaseForm, IFilerView
    {
        public FilerFormView()
        {
            InitializeComponent();
        }

        public void Start()
        {
            /*string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string parentDir = System.IO.Directory.GetParent(baseDir).ToString();
            string gParentDir = System.IO.Directory.GetParent(parentDir).ToString();
            openFile.InitialDirectory = gParentDir + @"\saves";*/
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public new string[] Load()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Load level";
            openFile.Filter = "TXT files|*.txt";
            openFile.InitialDirectory = @"E:\saves\";
            string[] newLevel = { "", "" };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFile.OpenFile() != null)
                    {
                        string filename = openFile.FileName;
                        string rawLevel = System.IO.File.ReadAllText(filename);
                        //MessageBox.Show(rawLevel);
                        newLevel[0] = filename;
                        newLevel[1] = rawLevel;
                        //return newLevel;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return newLevel;
        }

        public string Save()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save Game Progress";
            saveFile.InitialDirectory = @"E:\saves\";
            saveFile.FileName = "sokoban_lvl";
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                return saveFile.FileName;
            }
            else
            {
                throw new ArgumentException("To save a file you must select a directory");
            }
        }
    }
}
