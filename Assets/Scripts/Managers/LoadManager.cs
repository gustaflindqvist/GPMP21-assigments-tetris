using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gustaf.Scripts.Managers
{
    public class LoadManager : MonoBehaviour
    {
        public static LoadManager Instance;
        //private static GameObject _player;

        private void Awake()
        {
            Instance = this;
        }

        public static IEnumerator StartupCoroutine()
        {
            var camera = Instantiate(Resources.Load<GameObject>("GameCamera"));
            DontDestroyOnLoad(camera);

            if (Debug.isDebugBuild)
                yield return SceneManager.LoadSceneAsync("Scenes/Gustaf_Debug", LoadSceneMode.Additive);

            // Check scene
            var currentScene = SceneManager.GetActiveScene();
            switch (currentScene.name)
            {
                case "Gustaf_Start":
                    Instance.StartCoroutine(StartSceneRoutine());
                    break;
                case "Gustaf_Level1":
                    Instance.StartCoroutine(GoToGameRoutine());
                    break;
                case "Gustaf_Menu":
                    Instance.StartCoroutine(GoToMenuRoutine());
                    break;
                case "Gustaf_Hud":
                    Instance.StartCoroutine(GoToHudRoutine());
                    break;
                default:
                    // We should be in a game scene
                    break;
            }

            Debug.Log("Startup completed");
            yield break;
        }

        public static IEnumerator GoToGame()
        {
            yield return Instance.StartCoroutine(GoToGameRoutine());
            Debug.Log("Go to Game");
        }

        public static IEnumerator GoToMenu()
        {
            yield return Instance.StartCoroutine(GoToMenuRoutine());
            Debug.Log("Go to Menu");
        }

        public static IEnumerator GoToHud()
        {
            yield return Instance.StartCoroutine(GoToHudRoutine());
            Debug.Log("Go to Hud");
        }

        public static IEnumerator StartSceneRoutine()
        {
            // TODO: Move all this to startmenu instead
            yield return new WaitForSeconds(5f);
            Debug.Log("Start completed");
            yield return GoToMenu();
        }

        private static IEnumerator GoToHudRoutine()
        {
            // TODO Load loading screen (blackout screen)
            yield return UnloadAllScene(new[] {"Start", "Menu", "Level1", "Hud" });
            yield return Instance.StartCoroutine(LoadSceneRoutine("Scenes/Gustaf_Hud"));
            yield return Instance.StartCoroutine(HudManager.HudStartRoutine());
            // TODO: Fade out loading screen
            Debug.Log("Menu initialized");
        }

        private static IEnumerator GoToGameRoutine()
        {
            yield return UnloadAllScene(new[] { "Start", "Menu", "Level1", "Hud" });
            // Make sure that the game isn't playing
            yield return Instance.StartCoroutine(GameManager.GameEndRoutine());
            yield return Instance.StartCoroutine(LoadSceneRoutine("Scenes/Gustaf_Hud"));
            yield return Instance.StartCoroutine(LoadSceneRoutine("Scenes/Gustaf_Level1"));
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Gustaf_Level1"));
            // yield return Instance.StartCoroutine(LoadPlayer());
            yield return Instance.StartCoroutine(GameManager.GameStartRoutine());
        }

        // private static IEnumerator LoadPlayer()
        // {
        //     Debug.Log("Load player");
        //     // Create constant objects for all scenes
        //     _player = Instantiate(Resources.Load<GameObject>("Player"));
        //     DontDestroyOnLoad(_player);
        //     GameManager.Instance.Player = _player;
        //     yield break;
        // }

        private static IEnumerator GoToMenuRoutine()
        {
            // TODO: Load loading screen (blackout screen)
            yield return UnloadAllScene(new[] { "Start", "Menu", "Level1", "Hud" });
            yield return Instance.StartCoroutine(LoadSceneRoutine("Scenes/Gustaf_Menu"));
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Gustaf_Menu"));
            yield return Instance.StartCoroutine(MenuManager.Instance.MenuStartRoutine());

            // TODO: Fade out loading screen
            Debug.Log("Menu initialized");
        }

        private static IEnumerator LoadSceneRoutine(string sceneMenu)
        {
            yield return SceneManager.LoadSceneAsync(sceneMenu, LoadSceneMode.Additive);
        }

        private static IEnumerator UnloadAllScene(IReadOnlyList<string> allSceneNames)
        {
            for (var index = 0; index < allSceneNames.Count; index++)
            {
                yield return Instance.StartCoroutine(UnLoadSceneRoutine(allSceneNames[index]));
            }
        }
        private static IEnumerator UnLoadSceneRoutine(string sceneName)
        {
            var currentSceneName = $"Gustaf_{sceneName}";
            Debug.LogFormat("Current scene to be unload: {0} and is it loaded {1}",
                currentSceneName,
                SceneManager.GetSceneByName(currentSceneName).isLoaded);
            if (SceneManager.GetSceneByName(currentSceneName).isLoaded)
                yield return SceneManager.UnloadSceneAsync(currentSceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
    }
}
