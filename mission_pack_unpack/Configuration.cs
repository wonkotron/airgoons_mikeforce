﻿using System;

using Config.Net;

namespace mission_pack_unpack {
    public static class Configuration {
        public interface ISettings {
            string SteamCmdPath { get; }
            string SteamPath { get; }
            string SteamApps_Arma3Tools_Path { get; }
            string SteamApps_MikeForce_Path { get; }
        }

        public static ISettings Settings {
            get {
                if (_settings == null) {
                    // Settings accessed before init, attempt to init
                    InitSettings();
                }

                return _settings;
            }
        }
        private static ISettings _settings = null;

        public static void InitSettings() {
            string filepath = "configuration.json";

            if (!System.IO.File.Exists(filepath)) {
                throw new ApplicationException(
                    string.Format("Configuration file does not exist:  {0}", filepath)
                );
            }

            else {
                Console.Out.WriteLine("Loading settings from {0}", filepath);

                _settings = new ConfigurationBuilder<ISettings>()
                    .UseJsonFile(filepath)
                    .Build();
            }

            if (_settings == null) {
                throw new ApplicationException("null settings after attempt to initialize");
            }
        }
    }
}
