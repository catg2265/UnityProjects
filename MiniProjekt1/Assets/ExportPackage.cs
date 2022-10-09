using UnityEngine;
using System.IO;
using UnityEditor;
public static class ExportPackage {
    [MenuItem("Export/Export with tags, layers and Input settings")]
    public static void Export()
    {
        string[] projectContent = new string[] {"Assets", "ProjectSettings/TagManager.asset","ProjectSettings/InputManager.asset","ProjectSettings/ProjectSettings.asset"};
        AssetDatabase.ExportPackage(projectContent, "Handin.unitypackage",ExportPackageOptions.Interactive | ExportPackageOptions.Recurse |ExportPackageOptions.IncludeDependencies);
    }
}