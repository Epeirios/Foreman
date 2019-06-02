using Foreman.Models.ControlModels;
using Foreman.Models.SerializableObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Models
{
    public class ModDirectory
    {
        public string Directory { get; private set; }
        public Dictionary<Mod, bool> ModInfoList { get; private set; }
        private Dictionary<string, bool> modList;

        public ModDirectory(ModList modList, string dir, string[] enabledMods)
        {
            Directory = dir;
            ModInfoList = RetrieveModsFromModList(dir, modList, enabledMods);
            this.modList = ParseModList(modList);
        }

        public Dictionary<Mod, bool> GetModInfoListBasedOnModList()
        {
            Dictionary<Mod, bool> modInfoList = this.ModInfoList;

            foreach (var item in modInfoList)
            {
                if (modList.Keys.Contains(item.Key.ModName))
                {
                    modInfoList[item.Key] = true;
                }
                else
                {
                    modInfoList[item.Key] = false;
                }
            }

            return modInfoList;
        }

        private Dictionary<Mod, bool> RetrieveModsFromModList(string dir, ModList modList, string[] enabledMods)
        {
            Dictionary<Mod, bool> modInfoList = new Dictionary<Mod, bool>();

            string[] modZips = System.IO.Directory.GetFiles(dir, "*.zip", SearchOption.TopDirectoryOnly);

            foreach (string modZip in modZips)
            {
                using (ZipStorer zip = ZipStorer.Open(modZip, FileAccess.Read))
                {
                    String outputDir = Path.Combine(Path.GetTempPath(), "FactorioForeman");

                    foreach (var fileEntry in zip.ReadCentralDir())
                    {
                        if (Path.GetFileName(fileEntry.FilenameInZip) == "info.json")
                        {
                            string modInfo = Path.Combine(outputDir, fileEntry.FilenameInZip);

                            zip.ExtractFile(fileEntry, modInfo);

                            string json = "";
                            Mod mod = null;

                            if (Utils.ReadJsonFile(modInfo, out json))
                            {
                                mod = new Mod(JsonConvert.DeserializeObject<ModInfo>(json));
                            }

                            if (mod == null)
                            {
                                break;
                            }

                            bool enabled = false;

                            foreach (var item in modList.mods)
                            {
                                if (item.name == mod.ModName)
                                {
                                    if (enabledMods.Contains(item.name))
                                    {
                                        enabled = true;
                                    }

                                    modInfoList.Add(mod, enabled);

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return modInfoList;
        }

        private Dictionary<string, bool> ParseModList(ModList modList)
        {
            Dictionary<string, bool> parsed = new Dictionary<string, bool>();

            foreach (ModListItem item in modList.mods)
            {
                parsed.Add(item.name, item.enabled);
            }

            return parsed;
        }

        public CheckedModListBoxItem[] GetCheckedListBoxItemsModList()
        {
            List<CheckedModListBoxItem> items = new List<CheckedModListBoxItem>();

            foreach (var item in ModInfoList)
            {
                items.Add(new CheckedModListBoxItem(item.Key.ModName, item.Key.ModTitle, ValidateDependeciesMod(item.Key), item.Value));
            }

            return items.ToArray();
        }

        private bool ValidateDependeciesMod(Mod mod)
        {
            return true;
        }

        public static ModDirectory GetModDirectoryFromDir(string dir, string[] enabledMods)
        {
            if (System.IO.Directory.Exists(dir))
            {
                string json = "";
                string modListFile = Path.Combine(dir, "mod-list.json");
                //string infoFile = Path.Combine(dir, "data", "base", "info.json");
                try
                {
                    if (!File.Exists(modListFile))
                    {
                        return null;
                    }
                    json = File.ReadAllText(modListFile);
                }
                catch (Exception)
                {
                    ErrorLogging.LogLine(string.Format("Mod directory at '{0}' has an invalid mod-list.json file", modListFile));
                }

                if (json == "")
                    return null;

                return new ModDirectory(JsonConvert.DeserializeObject<ModList>(json), dir, enabledMods);
            }
            return null;
        }
    }
}
