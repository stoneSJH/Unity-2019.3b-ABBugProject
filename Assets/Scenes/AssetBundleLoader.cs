using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class AssetBundleLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadSceneBundle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public string bundleFolderName = "AssetBundles";
    static int maxBundleIndex = 2;

    void LoadSceneBundle()
    {
        // (1) load asset bundle
        AssetBundle baseLoadedAssetBundle = null;
        string path = Path.Combine(Application.dataPath, bundleFolderName);
        for (int i = 0; i <= maxBundleIndex; i += 2)
        {
            var bundleName = string.Format("bundle{0}", i);
            var bundlePath = Path.Combine(path, bundleName);
            if (!File.Exists(bundlePath))
                continue;

            var bundle = AssetBundle.LoadFromFile(bundlePath);
            if (null == bundle)
            {
                Debug.Log("Failed to load AssetBundle: " + bundlePath);
            }

            baseLoadedAssetBundle = bundle;
        }


        // (2) loaded scenes from asset bundle
        string[] scenePath = baseLoadedAssetBundle.GetAllScenePaths();
        foreach (var p in scenePath)
        {
            SceneManager.LoadScene(p, LoadSceneMode.Additive);
            break;
        }
    }
}
