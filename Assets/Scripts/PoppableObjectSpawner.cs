
////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;
////using UnityEngine.Pool;

////public class PoppableObjectSpawner : MonoBehaviour
////{
////    [SerializeField] GameObject poppablePrefab;
////    [SerializeField] GameObject spawnPointsContainer; 
////    [SerializeField] float spawnoffset = 1.0f;
////    [SerializeField] float spawnIntensity = 1.0f;
////    [SerializeField] float spawnDelay = 1.0f;

////    private ObjectPool<GameObject> objectPool;
////    private Coroutine spawnCoroutine;

////    private void Start()
////    {
////        objectPool = new ObjectPool<GameObject>(CreatePoppableObject, OnGetPoppableObject, OnReleasePoppableObject);
////        StartSpawnCoroutine();
////    }

////    private GameObject CreatePoppableObject()
////    {
////        GameObject poppableObject = Instantiate(poppablePrefab);
////        poppableObject.GetComponent<Ipopable>().setpool(objectPool);
////        poppableObject.SetActive(false);
////        return poppableObject;
////    }

////    private void OnGetPoppableObject(GameObject poppableObject)
////    {
////        poppableObject.SetActive(true);
////    }

////    private void OnReleasePoppableObject(GameObject poppableObject)
////    {
////        poppableObject.SetActive(false);
////    }

////    private List<Transform> spawnPoints = new List<Transform>();

////    private void Awake()
////    {
////        if (spawnPointsContainer != null)
////        {
////            foreach (Transform child in spawnPointsContainer.transform)
////            {
////                spawnPoints.Add(child);
////            }
////        }
////    }

////    private void StartSpawnCoroutine()
////    {
////        spawnCoroutine = StartCoroutine(SpawnCoroutine());
////    }

////    private void StopSpawnCoroutine()
////    {
////        if (spawnCoroutine != null)
////        {
////            StopCoroutine(spawnCoroutine);
////        }
////    }

////    private IEnumerator SpawnCoroutine()
////    {
////        while (true)
////        {
////            SpawnObjectsAtRandomPoints();
////            yield return new WaitForSeconds(spawnDelay);
////        }
////    }

////    public void SpawnPoppableObject(Vector3 position)
////    {
////        GameObject poppableObject = objectPool.Get();
////        poppableObject.transform.position = position;
////    }

////    public void SpawnObjectsAtRandomPoints()
////    {
////        int spawnCount = Mathf.RoundToInt(spawnIntensity);

////        for (int i = 0; i < spawnCount; i++)
////        {
////            int randomIndex = Random.Range(0, spawnPoints.Count);
////            Transform spawnPoint = spawnPoints[randomIndex];

////            Vector3 randomOffset = Random.insideUnitSphere * spawnoffset;
////            Vector3 spawnPosition = spawnPoint.position + randomOffset;

////            SpawnPoppableObject(spawnPosition);
////        }
////    }
////}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Pool;

//public class PoppableObjectSpawner : MonoBehaviour
//{
//    [SerializeField] List<GameObject> poppablePrefabs = new List<GameObject>();
//    [SerializeField] GameObject spawnPointsContainer;
//    [SerializeField] float spawnOffset = 1.0f;
//    [SerializeField] List<float> spawnChances = new List<float>();
//    [SerializeField] float spawnDelay = 1.0f;
//    [SerializeField] float spawnIntensity = 1.0f;

//    public ObjectPool<GameObject> objectPool;
//    private Coroutine spawnCoroutine;

//    private void Start()
//    {
//        objectPool = new ObjectPool<GameObject>(CreatePoppableObject, OnGetPoppableObject, OnReleasePoppableObject);
//        StartSpawnCoroutine();
//    }

//    private GameObject CreatePoppableObject()
//    {
//        int prefabIndex = RandomWeightedIndex(spawnChances);
//        GameObject poppableObject = Instantiate(poppablePrefabs[prefabIndex]);

//        Ipopable poppableScript = poppableObject.GetComponent<Ipopable>();
//        if (poppableScript != null)
//        {
//            poppableScript.setpool(objectPool);
//        }

//        poppableObject.SetActive(false);
//        return poppableObject;
//    }

//    private void OnGetPoppableObject(GameObject poppableObject)
//    {
//        poppableObject.SetActive(true);
//    }

//    private void OnReleasePoppableObject(GameObject poppableObject)
//    {
//        poppableObject.SetActive(false);
//    }

//    private List<Transform> spawnPoints = new List<Transform>();

//    private void Awake()
//    {
//        if (spawnPointsContainer != null)
//        {
//            foreach (Transform child in spawnPointsContainer.transform)
//            {
//                spawnPoints.Add(child);
//            }
//        }
//    }

//    private void StartSpawnCoroutine()
//    {
//        spawnCoroutine = StartCoroutine(SpawnCoroutine());
//    }

//    private void StopSpawnCoroutine()
//    {
//        if (spawnCoroutine != null)
//        {
//            StopCoroutine(spawnCoroutine);
//        }
//    }

//    private IEnumerator SpawnCoroutine()
//    {
//        while (true)
//        {
//            SpawnObjectsAtRandomPoints();
//            yield return new WaitForSeconds(spawnDelay);
//        }
//    }

//    public void SpawnPoppableObject(Vector3 position)
//    {
//        GameObject poppableObject = objectPool.Get();
//        poppableObject.transform.position = position;
//    }

//    public void SpawnObjectsAtRandomPoints()
//    {
//        int spawnCount = Mathf.RoundToInt(poppablePrefabs.Count * spawnOffset * spawnIntensity);

//        for (int i = 0; i < spawnCount; i++)
//        {
//            int randomIndex = Random.Range(0, spawnPoints.Count);
//            Transform spawnPoint = spawnPoints[randomIndex];

//            Vector3 randomOffset = Random.insideUnitSphere * spawnOffset;
//            Vector3 spawnPosition = spawnPoint.position + randomOffset;

//            SpawnPoppableObject(spawnPosition);
//        }
//    }

//    private int RandomWeightedIndex(List<float> weights)
//    {
//        float totalWeight = 0;

//        foreach (float weight in weights)
//        {
//            totalWeight += weight;
//        }

//        float randomValue = Random.Range(0, totalWeight);
//        float cumulativeWeight = 0;

//        for (int i = 0; i < weights.Count; i++)
//        {
//            cumulativeWeight += weights[i];
//            if (randomValue <= cumulativeWeight)
//            {
//                return i;
//            }
//        }

//        return weights.Count - 1;
//    }
//}








using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoppableObjectSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> poppablePrefabs = new List<GameObject>();
    [SerializeField] GameObject spawnPointsContainer;
    [SerializeField] float spawnOffset = 1.0f;
    [SerializeField] List<float> spawnChances = new List<float>();
    [SerializeField] float spawnDelay = 1.0f;
    [SerializeField] float spawnIntensity = 1.0f;

    public ObjectPool<GameObject> objectPool;
    private Coroutine spawnCoroutine;
    [SerializeField] GameObject BubblesPool;

    private void Start()
    {
        objectPool = new ObjectPool<GameObject>(CreatePoppableObject, OnGetPoppableObject, OnReleasePoppableObject);
        StartSpawnCoroutine();
    }

    private GameObject CreatePoppableObject()
    {
        int prefabIndex = RandomWeightedIndex(spawnChances);
        GameObject poppableObject = Instantiate(poppablePrefabs[prefabIndex], BubblesPool.transform);

        Ipopable poppableScript = poppableObject.GetComponent<Ipopable>();
        if (poppableScript != null)
        {
            poppableScript.setpool(objectPool);
        }

        poppableObject.SetActive(false);
        return poppableObject;
    }

    private void OnGetPoppableObject(GameObject poppableObject)
    {
        poppableObject.SetActive(true);
    }

    private void OnReleasePoppableObject(GameObject poppableObject)
    {
       
        poppableObject.SetActive(false);

    }

  

    private List<Transform> spawnPoints = new List<Transform>();

    private void Awake()
    {
        if (spawnPointsContainer != null)
        {
            foreach (Transform child in spawnPointsContainer.transform)
            {
                spawnPoints.Add(child);
            }
        }
    }

    private void StartSpawnCoroutine()
    {
        spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    private void StopSpawnCoroutine()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnObjectsAtRandomPoints();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnPoppableObject(Vector3 position)
    {
        GameObject poppableObject = objectPool.Get();
        poppableObject.transform.position = position;
    }

    public void SpawnObjectsAtRandomPoints()
    {
        int spawnCount = Mathf.RoundToInt(poppablePrefabs.Count * spawnOffset * spawnIntensity);

        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomIndex];

            Vector3 randomOffset = Random.insideUnitSphere * spawnOffset;
            Vector3 spawnPosition = spawnPoint.position + randomOffset;

            SpawnPoppableObject(spawnPosition);
        }
    }

    private int RandomWeightedIndex(List<float> weights)
    {
        float totalWeight = 0;

        foreach (float weight in weights)
        {
            totalWeight += weight;
        }

        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        for (int i = 0; i < weights.Count; i++)
        {
            cumulativeWeight += weights[i];
            if (randomValue <= cumulativeWeight)
            {
                return i;
            }
        }

        return weights.Count - 1;
    }
}
