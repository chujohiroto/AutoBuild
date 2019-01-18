using UnityEditor;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace iRosSoftware.AutoBuild
{
    public class BuildClass
    {
        public static EditorBuildSettingsScene[] GetEditorBuildSettingsScenes()
        {
            // ビルド対象シーンリスト
            List<EditorBuildSettingsScene> allScene = new List<EditorBuildSettingsScene>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                {
                    allScene.Add(scene);
                }
            }
            return allScene.ToArray();
        }

        public static void Build()
        {
            string outputpath = GetProjectBuildPath();
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            BuildOptions option = BuildOptions.None;
            var args = Environment.GetCommandLineArgs();
            int i, len = args.Length;


            for (i = 0; i < len; ++i)
            {
                switch (args[i])
                {
                    case "/output":
                        outputpath = args[i + 1];
                        break;

                    case "/platform":
                        switch(args[i + 1])
                        {
                            case "Win":
                                target = BuildTarget.StandaloneWindows;
                                break;
                            case "Win64":
                                target = BuildTarget.StandaloneWindows64;
                                break;
                            case "OSX":
                                target = BuildTarget.StandaloneOSX;
                                break;
                            case "Linux":
                                target = BuildTarget.StandaloneLinux;
                                break;
                            case "Linux64":
                                target = BuildTarget.StandaloneLinux64;
                                break;
                            case "LinuxU":
                                target = BuildTarget.StandaloneLinuxUniversal;
                                break;
                            case "iOS":
                                target = BuildTarget.iOS;
                                break;
                            case "Android":
                                target = BuildTarget.Android;
                                break;
                            case "WebGL":
                                target = BuildTarget.WebGL;
                                break;
                        }
                        break;

                    case "-dev":
                        option = BuildOptions.Development;
                        break;
                }
            }
            var s = string.Format("{0}/{1}/{2}/{3}", outputpath, Application.productName,
                DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), Application.productName);

            Debug.Log("Build Start:" + s);

            Build(target, option,s);
        }

        public static void Build(BuildTarget target, BuildOptions option, string outputpath = "")
        {
            if (outputpath == "")
            {
                outputpath = GetProjectBuildPath();
            }

            var filename = Application.productName;
#if UNITY_EDITOR
            filename += ".exe";
#endif
            var builds = BuildPipeline.BuildPlayer(GetEditorBuildSettingsScenes(),
                string.Format("{0}/{1}/{2}", outputpath,
                DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), filename),
                target, option);
        }

        public static string GetProjectPath()
        {
            var projectFolder = System.IO.Directory.GetCurrentDirectory();
            return projectFolder;
        }

        public static string GetProjectBuildPath()
        {
            return GetProjectPath() + "/Build";
        }
    }

}