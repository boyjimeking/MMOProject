using UnityEditor;
using System.Collections.Generic;

public class JenkinsBuilder
{
    // ビルド実行でAndroidのapkを作成する例
    [UnityEditor.MenuItem("Tools/Build Android")]
    public static void BuildAndroid() {
        EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
        List<string> allScene = new List<string>();
        foreach( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ){
            if (scene.enabled) {
                allScene.Add (scene.path);
            }
        }   
        PlayerSettings.bundleIdentifier = "mtmt.szk.ssk.YCGame";
        PlayerSettings.statusBarHidden = true;
        BuildPipeline.BuildPlayer( 
            allScene.ToArray(),
            "YCGame.apk",
            BuildTarget.Android,
            BuildOptions.None
        );
    }
}
