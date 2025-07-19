
using UnityEngine;

using System;

public class BulletScript : MonoBehaviour
{
    [SerializeField] AsteroidData data;
    public BulletScript instance { get; set; }

    void Update()
    {
        // Wrap bullet to other side of screen.
        if (transform.position.x < -8.5f)
        {
            transform.position = new Vector2(8.5f, transform.position.y);
        }
        else if (transform.position.x > 8.5f)
        {
            transform.position = new Vector2(-8.5f, transform.position.y);
        }
        if (transform.position.y < -6.5f)
        {
            transform.position = new Vector2(transform.position.x, 6.5f);
        }
        else if (transform.position.y > 6.5f)
        {
            transform.position = new Vector2(transform.position.x, -6.5f);
        }
    }

     public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
            // Get the destroyed asteroid script
            AsteroidScript destroyedAsteroid = collision.gameObject.GetComponent<AsteroidScript>();
            Color color = AsteroidManager.Instance.asteroidParent.GetComponentInChildren<SpriteRenderer>().color;
            

            // Call the CreateAsteroidChunks method from the destroyed asteroid
            if (Mathf.Approximately(destroyedAsteroid.transform.localScale.x, 1f))
            {
                destroyedAsteroid.CreateAsteroidChunks(.75f, color, transform.forward);
            }
            else if (Mathf.Approximately(destroyedAsteroid.transform.localScale.x, .75f))
            {
                destroyedAsteroid.CreateAsteroidChunks(.5f, color, transform.forward);
            }

            Destroy(gameObject);
            int index = AsteroidManager.Instance.GetAsteroids().IndexOf(collision.gameObject);
            if (index != -1)
                AsteroidManager.Instance.DeleteAsteroid(index); // Just two lines for readability.
        }
        //{
        //    Destroy(gameObject);

        //    // When an asteroid gets destroyed, make smaller chunks two times.
        //    int index = AsteroidManager.Instance.GetAsteroids().IndexOf(collision.gameObject);

        //    if (index != -1)
        //    {
        //        // Get the destroyed asteroid script
        //        AsteroidScript destroyedAsteroid = collision.gameObject.GetComponent<AsteroidScript>();

        //        // Call the CreateAsteroidChunks method from the destroyed asteroid
        //        destroyedAsteroid.CreateAsteroidChunks(); // Change the number of chunks as needed

        //        // Delete the original asteroid
        //        AsteroidManager.Instance.DeleteAsteroid(index);
        //    }
        //}
    }
}
