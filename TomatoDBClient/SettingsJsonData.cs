using System.IO;

using Newtonsoft.Json.Linq;

namespace TomatoDBClient
{
    public class SettingsJsonData
    {
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }

        public SettingsJsonData()
        {
            Reset();
        }

        private void Reset()
        {
            ServerIP = "";
            ServerPort = 0;
        }

        public bool ReadSettingsJsonData(string folderPath)
        {
            Reset();

            string jsonFile = folderPath + @"\config.json";
            bool jsonFileFound = false;

            if (File.Exists(jsonFile))
            {
                jsonFileFound = true;
                using (StreamReader r = new StreamReader(jsonFile))
                {
                    var json = r.ReadToEnd();
                    JObject jObject = JObject.Parse(json);
                    JValue jv = (JValue)jObject["ServerIP"];
                    ServerIP = jv.Value.ToString();

                    jv = (JValue)jObject["ServerPort"];
                    ServerPort = int.Parse(jv.Value.ToString());
                }
            }
            return jsonFileFound;
        }

    }
}
