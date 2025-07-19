using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager Instance { get; private set; } // Static object of the class.

    [SerializeField] public GameObject asteroidParent;
    [SerializeField] int asteroidCount;
    private List<GameObject> asteroids;

    private void Awake() // Ensure there is only one instance.
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances.
        }
    }

    void Initialize()
    {
        asteroids = new List<GameObject>();
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        float offSet = 12f / (asteroidCount / 2);
        for (int i = 0; i < asteroidCount / 2; i++)
        {
            GameObject roidInst = GameObject.Instantiate(asteroidParent, new Vector3(-6f + i * offSet + offSet / 2, 4f, 0f), Quaternion.identity);
            asteroids.Add(roidInst);
            roidInst = GameObject.Instantiate(asteroidParent, new Vector3(-6f + i * offSet + offSet / 2, -4f, 0f), Quaternion.identity);
            asteroids.Add(roidInst);
        }
    }

    public List<GameObject> GetAsteroids()
    {
        return asteroids;
    }

    public void DeleteAsteroid(int index)
    {
        Destroy(asteroids[index]);
        asteroids.RemoveAt(index);
        if (Game.Instance != null)
            Game.Instance.SOMA.PlaySound("Explode");
    }
}
