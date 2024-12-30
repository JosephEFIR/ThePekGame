using Project.Scripts.Configs;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Project.Scripts.Editor
{
    public class ConfigsEditor: OdinMenuEditorWindow
    {
        private const string CONFIG_PATH = "Assets/Project/Configs/";
        
        private const string CONFIG_TEST = CONFIG_PATH + "UnitSettings.asset";
        
        [MenuItem("Tools/Configs Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<ConfigsEditor>();

            SetSettings(window);
        }

        private static void SetSettings(ConfigsEditor window)
        {
            window.titleContent = new GUIContent("Configs Editor");

            Vector2 size = new Vector2(630, 700);
            window.minSize = size;
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var menuTree = new OdinMenuTree();
            
            menuTree.AddAssetAtPath("Unit/Settings", CONFIG_TEST, typeof(UnitSettings));

            return menuTree;
        }
    }
}