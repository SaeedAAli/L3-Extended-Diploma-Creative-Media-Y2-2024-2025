    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class AysnchronousLoader : MonoBehaviour
    {
        public GameObject loadingScreen;
        public Slider LoadingBar;
        public void LoadScene(string scenename)
        {
            StartCoroutine(LoadSceneAsync(scenename));
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;

            loadingScreen.SetActive(true);

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;

            while (operation.progress < 0.9f)
            {
                LoadingBar.value = operation.progress / 0.9f;
                yield return null;
            }

            LoadingBar.value = 1f;

            yield return new WaitForSeconds(3f);

            operation.allowSceneActivation = true;
            

            while (!operation.isDone)
            {
                yield return null;
            }

            loadingScreen.SetActive(false);
        }
    }