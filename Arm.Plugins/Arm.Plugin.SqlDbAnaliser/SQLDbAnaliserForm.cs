using System.Windows.Forms;
using Arm.Plugin.Type.Interfaces;



namespace SQLDbAnaliser
{
    public partial class SqlDbAnaliserForm : Form, IPluginForm
    {
        private const string m_PluginName = @"SQLDbAnaliserForm";
        private const string m_PluginDescription = @"SQLDbAnaliserForm";
        private const string m_Version = @"1.1.1.1";

        private SqlDbAnaliserFormController m_Controller;
        public SqlDbAnaliserForm()
        {
            InitializeComponent();

            m_Controller = new SqlDbAnaliserFormController( this );
        }


        public string PluginName
        {
            get { return m_PluginName; }
        }

        public string PluginDescription
        {
            get { return m_PluginDescription; }
        }

        public string Version
        {
            get { return m_Version; }
        }


        public void SetMdiParentForn( Form aMdiParent )
        {
            MdiParent = aMdiParent;
        }

        public void SetText( string aText )
        {
            Text = aText;
        }

        public new void Show()
        {
            base.Show();
        }
    }
}
