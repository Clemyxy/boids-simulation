using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {
namespace Info {

public class ShowDirection : MonoBehaviour {

    [SerializeField]
    private float length = 1f;

    [SerializeField]
    private Color color = Color.white;

    private Collection collection;

    void Start() {
        collection = GetComponent<Collection>();
    }

    void Update() {
        foreach(var boid in collection.Boids)
            Debug.DrawLine(boid.Position, boid.Position + length * boid.Direction, color);
    }
}

} // namespace Info
} // namespace Boid
