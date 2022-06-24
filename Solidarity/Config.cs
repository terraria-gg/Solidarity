﻿using Newtonsoft.Json;

namespace Solidarity
{
    public class Config
    {
        public static Settings Settings { get; private set; }
            = Settings.Read();
    }

    public class Settings
    {
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public ulong VoteChannel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ulong VoteRole { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] Emotes { get; set; } = Array.Empty<string>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<ulong, string[]> ChannelHandleCallback { get; set; } = new();

        public static Settings Read()
        {
            string path = "Config.json";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(new Settings(), Formatting.Indented));
                return new Settings();
            }
            return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path))
                ?? throw new NullReferenceException();
        }
    }
}
