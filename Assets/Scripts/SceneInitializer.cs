using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [Header("Scene Router")]
    [SerializeField] private GameObject sceneRouterPrefab;

    private void Awake()
    {
        // Ensure SceneRouter exists
        if (SceneRouter.Instance == null)
        {
            if (sceneRouterPrefab != null)
            {
                Instantiate(sceneRouterPrefab);
            }
            else
            {
                GameObject routerObj = new GameObject("SceneRouter");
                routerObj.AddComponent<SceneRouter>();
            }
        }
    }
}
