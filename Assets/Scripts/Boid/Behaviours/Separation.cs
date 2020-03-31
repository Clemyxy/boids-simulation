using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boid {
namespace Behaviours {

public class Separation : MonoBehaviour {
    //Structure de boid pour envoyer les informations au shader
    private struct separationBoid{
        public Vector3 position, acceleration;
    }
    
    [SerializeField]
    public ComputeShader cshader;

    [SerializeField]
    private float intensity = 0f;

    [SerializeField]
    private float radius = 0f;

    private separationBoid[] separationData;
    private Collection collection;

    private int kernelHandle;

    private ComputeBuffer separationBuffer;

    void Start() {
        collection = GetComponent<Collection>();
        kernelHandle = cshader.FindKernel("SeparationKernel"); //Initialise l'index du kernel
        separationBuffer = new ComputeBuffer(collection.Count, 3*2*sizeof(float));
    }

    void FixedUpdate() {
        //Crée le tableau de positions et acceleration de boids de cette frame
        this.separationData = new separationBoid[collection.Count];
        int boidsCount = 0;
        foreach(var current in collection.Boids) {
            separationData[boidsCount].position = current.Position;
            separationData[boidsCount].acceleration = current.Acceleration;
            boidsCount++;
        }

        //Met a jour le buffer d'alignement
        separationBuffer.SetData(this.separationData);

        //Met a jour le shader
        cshader.SetBuffer(this.kernelHandle, "currentBuffer", separationBuffer);
        cshader.SetFloat("intensity", intensity);
        cshader.SetFloat("radius", radius);
        cshader.SetFloat("boidsCount", boidsCount);

        //Execute le shader
        cshader.Dispatch(this.kernelHandle, collection.Count, 1, 1);

        //Recupère les infos du shader une fois les calculs finis et désalloue le buffer
        separationBuffer.GetData(this.separationData);

        //Met a jour chaque boids
        boidsCount = 0;
        foreach(var current in collection.Boids) {
            current.Acceleration +=  separationData[boidsCount].acceleration;
            boidsCount++;
        }
    }

    void OnDestroy(){
        separationBuffer.Release();
    }
}

} // namespace Behaviour
} // namespace Boid
