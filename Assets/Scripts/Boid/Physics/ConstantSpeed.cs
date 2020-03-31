using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {
namespace Physics {

public class ConstantSpeed : MonoBehaviour {

    public float value = 1f;

    private Collection collection;

    void Start() {
        collection = GetComponent<Collection>();
    }
    
    void FixedUpdate() {
        foreach(var boid in collection.Boids) {
            boid.Speed = value;
        }
    }
}

} // namespace Physics
} // namespace Boid
