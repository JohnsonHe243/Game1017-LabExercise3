
using UnityEngine;

[CreateAssetMenu(menuName = "ScritableObject/AsteroidData")]
public class AsteroidData : ScriptableObject
{
    public float[] minDirections;
    public float[] maxDirections;
    public float[] scales;
}
