using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaSelector.GUI
{
    /// <summary>
    /// Interaction logic for DirectorySelectionPrompt.xaml
    /// </summary>
    public partial class DirectorySelectionPrompt : UserControl
    {
        public DirectorySelectionPrompt(Dictionary<string, List<string>> mediaFilePaths)
        {
            InitializeComponent();

            Height = Math.Max(300, Math.Min(450, mediaFilePaths.Keys.Count * 50));
            foreach (string directory in mediaFilePaths.Keys)
            {
                Button directoryButton = new Button()
                {
                    Content = directory,
                    Height = 50
                };
                directoryButton.Click += (sender, e) =>
                {
                    ShowSelectedInExplorer.FilesOrFolders(mediaFilePaths[directory]
                        .SelectMany(file => Directory.GetFiles(directory, $"{file}*")));
                };
                Directories.Children.Add(directoryButton);
            }
        }
    }
}
