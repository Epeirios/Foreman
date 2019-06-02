namespace Foreman.Models.SerializableObjects
{
    public class ModInfo
    {
        public string name { get; set; }
        public string version { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string contact { get; set; }
        public string homepage { get; set; }
        public string factorio_version { get; set; }
        public string[] dependencies { get; set; }
        public string description { get; set; }
    }
}
