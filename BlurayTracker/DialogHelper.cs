using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BlurayTracker
{
    public class DialogHelper
    {
        private string jsonLoadFilePath = string.Empty;
        private string jsonSaveFilePath = string.Empty;

        public DialogHelper()
        {

        }

        public void SaveFile(List<Movie> movies)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "D:\\movieslist";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    if (!saveFileDialog.FileName.Contains(".json"))
                    {
                        fileName = fileName + ".json";
                    }

                    using (StreamWriter file = File.CreateText(fileName))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, movies);
                    }
                }                         
            }
        }

        public List<Movie> LoadFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\movieslist";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.jsonLoadFilePath = openFileDialog.FileName;
                
                    List<Movie> moviesJson = JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(this.jsonLoadFilePath));

                    return moviesJson;
                } else
                {
                    return null;
                }
            }
        }
    }
}
