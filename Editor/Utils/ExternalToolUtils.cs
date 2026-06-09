using System.Diagnostics;
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditorInternal;
using System.Threading.Tasks;

namespace FZTools
{

    [UnityEditor.InitializeOnLoad]
    public class PackageInstallChecker
    {
        static PackageInstallChecker()
        {
            ExternalToolUtils.CheckInstalled();
        }
    }

    public static class ExternalToolUtils
    {
        public static readonly string PACKAGE_MA = "nadena.dev.modular-avatar";
        public static readonly string PACKAGE_AAO = "com.anatawa12.avatar-optimizer";
        public static readonly string PACKAGE_LILYCAL = "jp.lilxyzw.lilycalinventory";

        private static List<string> packageList = new() { PACKAGE_MA, PACKAGE_AAO, PACKAGE_LILYCAL };

        private static Dictionary<string, bool> packageInstalledDict = null;

        public static void CheckInstalled()
        {
            UnityEngine.Debug.LogWarning("CheckInstalled()");
            if (packageInstalledDict != null)
            {
                UnityEngine.Debug.LogWarning("IS CHECKED!");
                return;
            }

            var packages = Client.List();
            while (!packages.IsCompleted) { }
            packageInstalledDict = new()
            {
                {PACKAGE_MA, packages.Result.FirstOrDefault(p => p.name == PACKAGE_MA) != null},
                {PACKAGE_AAO, packages.Result.FirstOrDefault(p => p.name == PACKAGE_AAO) != null},
                {PACKAGE_LILYCAL, packages.Result.FirstOrDefault(p => p.name == PACKAGE_LILYCAL) != null},
            };
        }

        public static bool IsInstalledMA()
        {
            if (packageInstalledDict != null)
            {
                return packageInstalledDict[PACKAGE_MA];
            }
            CheckInstalled();
            return packageInstalledDict[PACKAGE_MA];
        }

        public static bool IsInstalledAAO()
        {
            if (packageInstalledDict != null)
            {
                return packageInstalledDict[PACKAGE_AAO];
            }
            CheckInstalled();
            return packageInstalledDict[PACKAGE_AAO];
        }

        public static bool IsInstalledLilycal()
        {
            if (packageInstalledDict != null)
            {
                return packageInstalledDict[PACKAGE_LILYCAL];
            }
            CheckInstalled();
            return packageInstalledDict[PACKAGE_LILYCAL];
        }
    }
}