using UnityEngine;

namespace Utils
{
    public class SceneData : MonoBehaviour
    {
        public Transform playerSpawnPoint;
        
        public GameObject playerPrefab;

        public float playerSpeed;
        
        public Camera mainCamera;

        public float smoothTime;
    
        public Vector3 followOffset;
    }
}
