using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// This class is responsible for loading assets from disk.
public class AssetLoader
{
    // This dictionary stores all of the assets that have been loaded into memory.
    private Dictionary<string, Asset> assetCache = new Dictionary<string, Asset>();
 
    // This method loads an asset from disk.
    public Asset LoadAsset(string assetPath)
    {
        // Check if the asset already exists in memory.
        if (assetCache.ContainsKey(assetPath))
        {
            // Return the asset from the cache.
            return assetCache[assetPath];
        }

        // The asset does not exist in memory, so load it from disk.
        Asset asset = AssetManager.LoadAsset(assetPath);

        // Add the asset to the cache.
        assetCache.Add(assetPath, asset);

        // Return the asset.
        return asset;
    }

    // This method unloads an asset from memory.
    public void UnloadAsset(string assetPath)
    {
        // Check if the asset exists in the cache.
        if (!assetCache.ContainsKey(assetPath))
        {
            // The asset does not exist in the cache, so do nothing.
            return;
        }

        // Remove the asset from the cache.
        assetCache.Remove(assetPath);

        // Unload the asset from memory.
        AssetManager.UnloadAsset(assetPath);
    }
}
