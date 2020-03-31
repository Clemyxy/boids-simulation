# Extended Boids Simulation

## Boids

This project's goal is to get a hang of Unity, while also learning about the boids (See resources for infos about them), and use them to learn about compute shaders.

### Getting Started

Project made with Unity 2019.2.19f1, get it here : https://unity.com/fr.
Then open the project with Unity.

### How to use

This project is not a game, and doesn't have any "play mode" controls, the only way to move around the scene is going into scene mode
 and moving with the keys binded in your editor preferences (usually WASD).

You can also have fun with the boids behaviour by editing the Cohesion,Attraction and Seperations intensitiy/radius variables and see how the boids react.

![Image Du Jeu](https://github.com/Clemyxy/boids-simulation/blob/master/BoidsScreen.png)
# Leads

## Performances

#### Done

- Compute Shaders

### To Consider

* Multithreading
  *Probably not that interesting considering that compute shaders are just a much better alternative in the case of Boids.   
  *Unity may not be thread-safe outside of its job system. It could be a hassle to use multithreading.

* Space partitioning

* Unity ECS
  *Adds a lot more complexity for a huge performance gain.

# Resources

## About Boids

### Articles

[(Conrad Parker) Boids Pseudocode](http://www.kfish.org/~conrad/boids/pseudocode.html)

[(Craig W. Reynolds) Boids: Background and Update](http://www.red3d.com/cwr/boids/)

### Papers

[(Craig W. Reynolds) Flocks, Herds, and Schools: A Distributed Behavioral Mode](http://www.cs.toronto.edu/~dt/siggraph97-course/cwr87/)

[(Craig W. Reynolds) Not Bumping Into Things](http://www.red3d.com/cwr/nobump/nobump.html)

### Other projects that I took informations from

[(Board To Bits Games) Flocking Algorithm in Unity](https://www.youtube.com/playlist?list=PL5KbKbJ6Gf99UlyIqzV1UpOzseyRn5H1d)

[(Raphael "Shinao" Monnerat) Unity GPU Boids](https://github.com/Shinao/Unity-GPU-Boids)

[(Sebastian Lague) Coding Adventure: Boids](https://www.youtube.com/watch?v=bqtqltqcQhw)

## Documentation

### About C#

[(Microsoft) Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)

[(Microsoft) Collections](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)


###About Unity


**[(Unity) Scripting API](https://docs.unity3d.com/2019.2/Documentation/ScriptReference/index.html)**

**[(Unity) User Manual](https://docs.unity3d.com/2019.2/Documentation/Manual/index.html)**

[(Unity) Compute Buffer](https://docs.unity3d.com/2019.2/Documentation/ScriptReference/ComputeBuffer.html)

[(Unity) Compute Shader](https://docs.unity3d.com/2019.2/Documentation/ScriptReference/ComputeShader.html)

[(Unity) Debug](https://docs.unity3d.com/ScriptReference/Debug.html)

[(Unity) GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html)

[(Unity) MonoBehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)

[(Unity) Object](https://docs.unity3d.com/ScriptReference/Object.html)

[(Unity) Physics](https://docs.unity3d.com/ScriptReference/Physics.html)

[(Unity) Quaternion](https://docs.unity3d.com/ScriptReference/Quaternion.html)

[(Unity) Transform](https://docs.unity3d.com/ScriptReference/Transform.html)

[(Unity) Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html)

