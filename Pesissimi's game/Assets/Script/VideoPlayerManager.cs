using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Com.AnDr3wS7oRc1.Pesissimisgame
{
    public class VideoPlayerManager : MonoBehaviour
    {
        [SerializeField] GameObject video;
        [SerializeField] GameObject image;
        [SerializeField] GameObject text;
        [SerializeField] GameObject loadingPanel;
        [SerializeField] Image imageLoading;
        [SerializeField] CanvasGroup cg;
        bool isPlayerStarted = false;

        void Start()
        {
            DontDestroyOnLoad(loadingPanel);
            //DontDestroyOnLoad(loadingPanel.transform.parent);
        }
        void Update()
        {
            VideoPlayer videoPlayer = video.GetComponent<VideoPlayer>();
            videoPlayer.loopPointReached += CheckOver;
            if (image.active == true)
            {
                text.SetActive(true);
            }

            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                StartCoroutine(LoadScene("Loading"));
            }
        }

        void CheckOver(UnityEngine.Video.VideoPlayer vp)
        {
            //vp.gameObject.SetActive(false);
            image.SetActive(true);
        }

        IEnumerator LoadScene(string sceneName)
        {
            image.SetActive(false);
            text.SetActive(false);
            loadingPanel.SetActive(true);
            imageLoading.transform.Rotate(0, 0, 2f, Space.Self);
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            while (operation.isDone)
            {
                yield return null;
            }
            StartCoroutine(FadeOutLoading(2f));
        }

        IEnumerator FadeOutLoading(float duration) {
            float timePassed = 0.0f;
            float startAlpha = 0.0f;

            while (timePassed < duration)
            {
                timePassed += Time.deltaTime;
                cg.alpha = Mathf.Lerp(1f, 0f, timePassed / duration);
                yield return null;
            }
            loadingPanel.SetActive(false);
            cg.alpha = 1f;
        }
    }
}