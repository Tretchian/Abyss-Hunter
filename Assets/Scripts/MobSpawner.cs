using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _larvaPrefab;
    [SerializeField] private float timeScale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject Larva = Instantiate(_larvaPrefab, new Vector2 (4.2f,0.5f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }
}
