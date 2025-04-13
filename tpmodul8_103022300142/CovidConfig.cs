using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;


namespace tpmodul8_103022300142
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_demam { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private static string configPath = "covid_config.json";

        public static CovidConfig LoadConfig()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    return JsonSerializer.Deserialize<CovidConfig>(json) ?? new CovidConfig();
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("❌ Format JSON tidak valid! Menggunakan konfigurasi default...");
            }

            return new CovidConfig();
        }


        public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configPath, json);
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }
            SaveConfig(); // save perubahan
        }
    }
}
//menyelesaikan program dengan runtime configuration