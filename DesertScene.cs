using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Numerics;
using UnityEngine;

public class CreateScene: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateGround();
        CreatePyramid();
        CreateRandomForest();
    }

    // Update is called once per frame
    void CreateGround()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer renderer = plane.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;
    }
    void CreateRandomForest() 
    {
        GameObject cylinderParent = new GameObject("CylinderParent");
        for (float tree = 0; tree < 10; tree++) {
            float px = UnityEngine.Random.Range(-1.5f, 1.5f);
            float pz = UnityEngine.Random.Range(-1.5f, 1.5f);
            float sx = UnityEngine.Random.Range(.5f, 1.5f);
            float sy = UnityEngine.Random.Range(.5f, 1.5f);
            float sz = UnityEngine.Random.Range(.5f, 1.5f);
            float g = UnityEngine.Random.Range(0f, 1f);
            Color newColor = new Color(0f, g, 0f);
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            Renderer renderer = cylinder.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Standard"));
            renderer.material.color = newColor;
            cylinder.transform.parent = cylinderParent.transform;
            cylinder.transform.position = new UnityEngine.Vector3(-2f+px, .5f*sy, 0f+pz);
            cylinder.transform.localScale = new UnityEngine.Vector3(.5f*sx, .5f*sy, .5f*sz);
        }
    }
    void CreatePyramid()
    {
        GameObject cubeParent = new GameObject("CubeParent");
        for (float level = 0f; level < 5f; level++)
        {
            float r = UnityEngine.Random.Range(0f, 1f);
            float g = UnityEngine.Random.Range(0f, 1f);
            float b = UnityEngine.Random.Range(0f, 1f);
            Color newColor = new Color(r, g, b);
            for (float row = 0f; row < (5f-level); row++)
            {
                for (float col = 0f; col < (5f-level); col++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Renderer renderer = cube.GetComponent<Renderer>();
                    renderer.material = new Material(Shader.Find("Standard"));
                    renderer.material.color = newColor;
                    cube.transform.parent = cubeParent.transform;
                    cube.transform.localScale = new UnityEngine.Vector3(.45f, .45f, .45f);
                    cube.transform.position = new UnityEngine.Vector3(1f+(.25f*level) + (col / 2f), .25f + (level / 2f), -1f+(.25f*level) + (row / 2f));
                }
            }
        }
    }
}
