using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Editor
{
    public static class BatchBuild
    {
        private static string BuildDirName = "Build";
        private static string WebBuildDirName = "Web";

        public static void BuildWebGL()
        {
            var buildDir = Path.Combine(Directory.GetCurrentDirectory(), BuildDirName);
            if (!Directory.Exists(buildDir))
            {
                Directory.CreateDirectory(buildDir);
            }

            var scenes = EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path).ToArray();
            BuildPlayerOptions options = new BuildPlayerOptions
            {
                scenes = scenes,
                locationPathName = Path.Combine(buildDir, WebBuildDirName),
                target = BuildTarget.WebGL,
                options = BuildOptions.None
            };
            // https://docs.unity3d.com/2020.1/Documentation/Manual/webgl-deploying.html
            // decompressionFallback は解凍できなかった場合に 未圧縮のゲームファイルを利用する設定。
            // 圧縮ファイルのレスポンスヘッダーに `Content-Type` を設定することでブラウザで解凍ができる。
            // github pages ではレスポンスヘッダーを設定できないため解凍ができない。
            // そのため decompressionFallback を有効にしている。
            PlayerSettings.WebGL.decompressionFallback = true;
            var report = BuildPipeline.BuildPlayer(options);
            var summary = report.summary;
            
            if (summary.result == BuildResult.Succeeded) {
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            }
            else
            {
                var errorString = new StringBuilder();
                var errorSteps = report.steps.Where(step => step.messages.Any(message => message.type == LogType.Error)).ToArray();
                errorString.AppendLine("BuildErrorMessage===================BEGIN");

                foreach (var errorStep in errorSteps)
                {
                    foreach (var message in errorStep.messages)
                    {
                        errorString.AppendLine(message.content);
                    }

                    errorString.AppendLine("------------");
                }

                errorString.AppendLine("BuildErrorMessage===================END");
                Debug.LogError(errorString);
                EditorApplication.Exit(1);
            }
        }
    }
}
