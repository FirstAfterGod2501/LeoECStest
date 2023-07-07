using UnityEngine;

namespace Utils
{
    public class SceneData : MonoBehaviour
    {
        public Transform playerSpawnPoint;

        public Transform PlayerTransform;
        
        public GameObject playerPrefab;

        public GameObject tilePrefab;

        public float playerSpeed;
        
        public Camera mainCamera;

        public float smoothTime;
    
        public Vector3 followOffset;
    }
}
