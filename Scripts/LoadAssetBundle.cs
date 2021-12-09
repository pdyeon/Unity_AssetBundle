using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{
    public string[] urlAddress;
    private string url; //"https://drive.google.com/uc?export=download&id=18Emh5s6oaO6tVCh9AS2DI2pVp_G2K-8K";



    public string[] modelNames;
    private string modelName; //"firtree"



    private GameObject[] obj;

    void Start()
    {
        obj = new GameObject[urlAddress.Length];

        StartCoroutine(WebReq());
    }

    
    IEnumerator WebReq()
    {
        for(int i = 0; i < urlAddress.Length; i++)
        {
            url = urlAddress[i];
            modelName = modelNames[i];

            WWW www = new WWW(url);

            yield return www;

            while (www.isDone == false)
            {
                yield return null;
            }

            AssetBundle bundle = www.assetBundle;

            if (www.error == null)
            {
                obj[i] = (GameObject)bundle.LoadAsset(modelName);
                Instantiate(obj[i]);
            }
            else
                Debug.Log(www.error);
        }
        
    }
    
}
