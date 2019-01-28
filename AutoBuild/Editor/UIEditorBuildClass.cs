using UnityEditor;

namespace iRosSoftware.AutoBuild
{
    public class UIEditorBuildClass
    {
        [MenuItem("AutoBuild/Windows64")]
        static void Windows64Build()
        {
            BuildClass.Build(BuildTarget.StandaloneWindows64,BuildOptions.None);
        }

        [MenuItem("AutoBuild/MacOSX")]
        static void MacOSXBuild()
        {
            BuildClass.Build(BuildTarget.StandaloneOSX, BuildOptions.None);
        }

        [MenuItem("AutoBuild/Linux64")]
        static void Linux64Build()
        {
            BuildClass.Build(BuildTarget.StandaloneLinux64, BuildOptions.None);
        }


        [MenuItem("AutoBuild/Android")]
        static void AndroidBuild()
        {
            BuildClass.Build(BuildTarget.Android, BuildOptions.None);
        }

        [MenuItem("AutoBuild/IOS")]
        static void IOSBuild()
        {
            BuildClass.Build(BuildTarget.iOS, BuildOptions.None);
        }
    }
}