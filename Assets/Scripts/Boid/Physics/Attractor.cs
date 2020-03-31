using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {
namespace Physics {

public class Attractor : MonoBehaviour {

    [SerializeField]
    private float intensity = 0f;

    private Collection collection;

    void Start() {
        collection = GetComponent<Collection>();
    }

    void FixedUpdate() {
        foreach(var boid in collection.Boids) {
            boid.Acceleration += - boid.Position * intensity;
        }
    }
}

} // Physics
} // Boid
