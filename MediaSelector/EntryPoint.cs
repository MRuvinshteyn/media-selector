using MediaSelector.GUI;
using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MediaSelector
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            var pool = vegas.Project.MediaPool;
            Dictionary<string, List<string>> mediaFilePaths = new Dictionary<string, List<string>>();

            foreach (Media media in pool)
            {
                if (media.IsValid() && File.Exists(media.FilePath))
                {
                    string path = media.FilePath;
                    FileInfo info = new FileInfo(path);
                    string directory = info.Directory.FullName;
                    string fileName = info.Name;
                    if (!mediaFilePaths.ContainsKey(directory))
                    {
                        mediaFilePaths.Add(directory, new List<string>() { fileName });
                    }
                    else
                    {
                        mediaFilePaths[directory].Add(fileName);
                    }
                }
            }

            var prompt = new Window
            {
                Title = "Select Directories",
                Content = new DirectorySelectionPrompt(mediaFilePaths),
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            prompt.Show();
        }
    }
}
