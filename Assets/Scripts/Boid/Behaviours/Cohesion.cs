using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boid {
namespace Behaviours {

public class Cohesion : MonoBehaviour {
    //Structure de boid pour envoyer les informations au shader
    private struct cohesionBoids{
        public Vector3 position, acceleration;
    }
    
    [SerializeField]
    public ComputeShader cshader;  

    [SerializeField]
    private float intensity = 0f;

    [SerializeField]
    private float radius = 0f;

    private cohesionBoids[] cohesionData;
    private Collection collection;

    private int kernelHandle;

    private ComputeBuffer cohesionBuffer;

    void Start() {
        collection = GetComponent<Collection>();
        kernelHandle = cshader.FindKernel("CohesionKernel"); //Initialise l'index du kernel
        cohesionBuffer = new ComputeBuffer(collection.Count, 3*2*sizeof(float));
        }

    void FixedUpdate() {
        //Crée le tableau de positions et acceleration de boids de cette frame
        this.cohesionData = new cohesionBoids[collection.Count];
        int boidsCount = 0;
        foreach(var current in collection.Boids) {
            cohesionData[boidsCount].position = current.Position;
            cohesionData[boidsCount].acceleration = current.Acceleration;
            boidsCount++;
        }
        
        //Met a jour le buffer de cohesion
        cohesionBuffer.SetData(this.cohesionData);

        //Met a jour le shader
        cshader.SetBuffer(this.kernelHandle, "currentBuffer", cohesionBuffer);
        cshader.SetFloat("intensity", intensity);
        cshader.SetFloat("radius", radius);
        cshader.SetFloat("boidsCount", boidsCount);

        //Execute le shader
        cshader.Dispatch(this.kernelHandle, collection.Count, 1, 1);

        //Recupère les infos du shader une fois les calculs finis et désalloue le buffer
        cohesionBuffer.GetData(this.cohesionData);

        //Met a jour chaque boids
        boidsCount = 0;
        foreach(var current in collection.Boids) {
            current.Acceleration +=  cohesionData[boidsCount].acceleration;
            boidsCount++;
        }
    }
    void OnDestroy(){
            cohesionBuffer.Release();
        }
}

} // namespace Behaviour
} // namespace Boid
