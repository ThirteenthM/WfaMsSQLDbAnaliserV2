namespace Arm.Plugin.Type.Classes
{
    public class PluginFormInfo
    {
        public string PlaginFileName { get; set; }
        public System.Type ClassType { get; set; }

        public string PluginName { get; set; }
        public string PluginDescription { get; set; }
        public string Version { get; set; }
        
        public PluginFormInfo( string aPlaginFileName, System.Type aClassType, string aPluginName, string aPluginDescription, string aVersion )
        {
            PlaginFileName = aPlaginFileName;
            ClassType = aClassType;

            PluginName = aPluginName;
            PluginDescription = aPluginDescription;
            Version = aVersion;
        }
    }
}
