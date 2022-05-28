using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Ulma
{
    [RequireComponent(typeof(SceneListProvider))]
    public class SceneManager : MonoBehaviour
    {
        public class ShareData
        {

        }

        private static SceneManager instance = null;
        public static SceneManager Instance
        {
            get {
                if (instance == null)
                {
                    instance = FindObjectOfType<SceneManager>();
                    if (instance == null)
                    {
                        throw new System.NullReferenceException();
                    }
                }
                return instance;
            }
        }

        [SerializeField]
        private string _ResidentSceneName = "Resident";

        public StageType CurrentStageType { get; private set; }
        public ShareData CurrentShareData { get; private set; }


        public void LoadStage(StageType stageType, System.Action<StageType> onLoadFinished = null, ShareData shareData = null)
        {
            StartCoroutine(LoadStageCoroutine(stageType, onLoadFinished, shareData));
        }


        public void LoadStage(StageType stageType, ShareData shareData)
        {
            StartCoroutine(LoadStageCoroutine(stageType, null, shareData));
        }


        private IEnumerator LoadStageCoroutine(StageType stageType, System.Action<StageType> onLoadFinished = null, ShareData shareData = null)
        {
            var sceneNames = SceneListProvider.Instance.GetSceneNames(stageType);

            var unloadSceneNames = new List<string>();
            for (int i=0; i<UnitySceneManager.sceneCount; i++)
            {
                var sceneName = UnitySceneManager.GetSceneAt(i).name;
                if (sceneName == _ResidentSceneName)
                {
                    continue;
                }
                unloadSceneNames.Add(sceneName);
            }

            foreach (var sceneName in unloadSceneNames)
            {
                yield return UnitySceneManager.UnloadSceneAsync(sceneName);
            }

            for (int i = 0; i < sceneNames.Count; i++)
            {
                //í’“ƒV[ƒ“‚È‚ç‰½‚à‚µ‚È‚¢.
                if (sceneNames[i] == _ResidentSceneName)
                {
                    continue;
                }

                yield return UnitySceneManager.LoadSceneAsync(sceneNames[i], LoadSceneMode.Additive);
            }

            for (int i = 0; i < UnitySceneManager.sceneCount; i++)
            {
                if (UnitySceneManager.GetSceneAt(i).name == sceneNames[0])
                {
                    UnitySceneManager.SetActiveScene(UnitySceneManager.GetSceneAt(i));
                }
            }

            onLoadFinished?.Invoke(stageType);
            CurrentStageType = stageType;
            CurrentShareData = shareData;
        }
    }
}
