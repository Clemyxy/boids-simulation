using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {

public class Collection : MonoBehaviour {

    private List<Boid.Data> boids = new List<Boid.Data>{};

    void Awake() {
        boids.AddRange(FindObjectsOfType<Boid.Data>());
    }

    public int Count {
        get => boids.Count;
    }

    public List<Boid.Data> Boids {
        get => boids;
    }
}

} // namespace Boid
