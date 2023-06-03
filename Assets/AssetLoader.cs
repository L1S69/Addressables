using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetLoader : MonoBehaviour
{
    private GameObject gameObjectToLoad;

    public void InstantiateGameObjectUsingAssetReference(string key)
    {
        Addressables.InstantiateAsync(key).Completed += OnLoadDone;
    }

    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        gameObjectToLoad = obj.Result;
    }

    public void ReleaseGameObjectUsingAssetReference()
    {
        Addressables.Release(gameObjectToLoad);
    }
}
