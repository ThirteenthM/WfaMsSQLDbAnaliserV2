using Arm.Plugin.Type;
using Arm.Plugin.Type.Interfaces;


namespace WfaMsSQLDbAnaliserV2
{
    public partial class MdiMainForm : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginHost
    {
        private readonly MdiMainFormController m_MdiMainFormController;
        //private int m_ChildFormNumber;

        public MdiMainForm ()
        {
            InitializeComponent ();

            m_MdiMainFormController = new MdiMainFormController( this );

            m_MdiMainFormController.SearchPluginForm();
        }

        public bool Register(IPluginForm aPlugin)
        {
            return true;
        }

        private void barButtonItem1_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            m_MdiMainFormController.CreaterPliginFormByName( @"SQLDbAnaliserForm" );
        }
    }
}
                                                 