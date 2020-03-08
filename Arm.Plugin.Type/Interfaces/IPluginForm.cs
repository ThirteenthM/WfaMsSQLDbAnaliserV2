using System.Windows.Forms;


namespace Arm.Plugin.Type.Interfaces
{
    public interface IPluginForm
    {
        string PluginName { get; }          // имя плагина
        string PluginDescription { get; }   // описание плагина
        string Version { get; }             // версия

        void SetMdiParentForn( Form aMdiParent );
        void SetText( string aText );
        void Show();
    }
}
