using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Starter
{
    private static bool _isInitalized;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnSceneLoad()
    {
        if (_isInitalized) return;

        var managerObject = new GameObject("GameManager");
        managerObject.AddComponent<GameManager>();
        managerObject.AddComponent<LoadManager>();
        managerObject.AddComponent<EventSystem>();
        managerObject.AddComponent<StandaloneInputModule>();
        // Remove after added all components
        Object.DontDestroyOnLoad(managerObject);

        LoadManager.Instance.StartCoroutine(LoadManager.StartupCoroutine());
        _isInitalized = true;
    }
}