using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils {

    public class SceneController : MonoBehaviour {

        public Animator crossfadeAnimator;
        public Animator musicFadeAnimator;
        private static readonly int StartTrigger = Animator.StringToHash("Start");

        private void Start() {
            crossfadeAnimator.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void ChangeScene(string scene) {
            StartCoroutine(DelayedSceneChange(scene));
        }

        [ContextMenu("ReloadScene")]
        public void ReloadScene() {
            ChangeScene(SceneManager.GetActiveScene().name);
        }

        public void ExitGame() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        private IEnumerator DelayedSceneChange(string sceneName) {
            if (crossfadeAnimator == null) {
                throw new System.ArgumentNullException("Animator was null.");
            }
            crossfadeAnimator.gameObject.SetActive(true);
            crossfadeAnimator.SetTrigger(StartTrigger);
            if (musicFadeAnimator) {
                musicFadeAnimator.SetTrigger(StartTrigger);
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //OptionsController.instance.isUiBlocking = true;
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(sceneName);
            //OptionsController.instance.isUiBlocking = false;
        }
    }
}