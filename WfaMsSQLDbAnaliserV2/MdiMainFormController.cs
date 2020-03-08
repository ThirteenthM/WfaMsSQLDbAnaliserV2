using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Arm.Plugin.Type.Classes;
using Arm.Plugin.Type.Interfaces;
using WfaMsSQLDbAnaliserV2.Classes;

namespace WfaMsSQLDbAnaliserV2
{
    class MdiMainFormController
    {
        private readonly MdiMainForm m_Form;
        private readonly SetupAplication m_SetupAplication;
        private readonly List<PluginFormInfo> m_PluginFormInfoList;


        public MdiMainFormController( MdiMainForm aForm )
        {
            m_Form = aForm;
            m_SetupAplication = new SetupAplication();
            m_PluginFormInfoList = new List<PluginFormInfo>();
        }

        public void SearchPluginForm()
        {
            var locRootPath = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location );
            if( locRootPath == null ) throw new ArgumentNullException( @"locRootPath" );
            var locPluginFormPath = Path.Combine( locRootPath, m_SetupAplication.SetupPluginForm.PluginFormDir );

            if( !Directory.Exists( locPluginFormPath ) )
                return;


            DirectoryInfo locDi = new DirectoryInfo( locPluginFormPath );
            DirectoryInfo[] locSubDir = locDi.GetDirectories();

            foreach( DirectoryInfo locItem in locSubDir )
            {
                CheckPathForPluginForm( Path.Combine( locPluginFormPath, locItem.Name ) );
            }
        }


        private void CheckPathForPluginForm( string aPlaginFormPath )
        {
            if( !Directory.Exists( aPlaginFormPath ) )
                return;

            DirectoryInfo locDi = new DirectoryInfo( aPlaginFormPath );
            FileInfo[] locFi = locDi.GetFiles( "*.dll", SearchOption.TopDirectoryOnly );

            m_PluginFormInfoList.Clear();

            foreach( FileInfo locItem in locFi )
            {
                //locItem.
                //CheckPluginFormForDll( Path.Combine( aPlaginFormPath, locItem.Name ) );
                CheckPluginFormForDll( locItem.FullName );
            }
        }


        private void CheckPluginFormForDll( string aPathNameDll )
        {
            if( aPathNameDll == null )
                return;

            if( !File.Exists( aPathNameDll ) )
                return;

            //if( Path.GetFileName( aPathNameDll ).ToLower() == "Arm.Plugin.Type.dll".ToLower() )
            //    return;


            Assembly locAsm = Assembly.LoadFrom( aPathNameDll );

            if( locAsm != null )
            {
                Type destType = typeof( IPluginForm );

                foreach( Type t in locAsm.GetExportedTypes() )
                {
                    if( destType.IsAssignableFrom( t ) )
                    {
                        IPluginForm locPi = (IPluginForm)locAsm.CreateInstance( t.FullName );

                        if( locPi != null )
                        {
                            var locNewPluginFormInfoItem = new PluginFormInfo( aPathNameDll, t, locPi.PluginName, locPi.PluginDescription, locPi.Version );
                            m_PluginFormInfoList.Add( locNewPluginFormInfoItem );
                        }
                    }
                }
            }
        }


        public void CreaterPliginFormByName( string aPluginName )
        {
            PluginFormInfo locPluginFormInfo = m_PluginFormInfoList.Find( t => t.PluginName == aPluginName );

            if( locPluginFormInfo == null )
                return;

            Assembly locAsm = Assembly.LoadFrom( locPluginFormInfo.PlaginFileName );

            if( locAsm == null )
                return;

            IPluginForm locIluginForm = (IPluginForm)locAsm.CreateInstance( locPluginFormInfo.ClassType.FullName );

            if( locIluginForm != null )
            {
                locIluginForm.SetMdiParentForn( m_Form );
                locIluginForm.SetText( locPluginFormInfo.PluginName );
                locIluginForm.Show();
            }
        }
    }
}
