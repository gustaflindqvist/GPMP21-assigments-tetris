using System.Collections;
using UnityEngine;

namespace Managers
{
    public class GameManager: MonoBehaviour
    {
        public static GameManager Instance;

        public static bool IsGameStarted = false;
        public static float Score { get; private set; } = 0;
        private static int _scores;
        public bool EnableAudio { get; set; } = false;
        // public GameObject Player { get; set; }
        public void Awake()
        {
            Score = 0;
            Instance = this;
        }

        private void Start()
        {
            InputManager.ActivateButtons();
            StartCoroutine(ScoreCounter());
        }

        public static IEnumerator GameStartRoutine()
        {
            IsGameStarted = true;
            Score = 0;
            Debug.Log("Game started");
            yield break;
        }

        public static IEnumerator GameEndRoutine()
        {
            IsGameStarted = false;
            Debug.Log("Game Ended");
            yield break;
        }

        private static IEnumerator ScoreCounter()
        {
            if (!IsGameStarted) yield break;
            while (_scores > 0)
            {
                _scores++;
                Debug.LogFormat("Score {0}", _scores);
                if (_scores > 5000) _scores = 0;
                Score = _scores;
                yield return new WaitForSeconds(0.2f);
            }
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            //If we are running in a standalone build of the game
            Application.Quit();
        }
    }
}
