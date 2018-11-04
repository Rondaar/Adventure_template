using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    Transform[] backgrounds;
    [SerializeField]
    float smoothing = 1;

    float[] parallaxScales;
    private Vector3 prevCamPos;
    Transform cam;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        prevCamPos = cam.position;
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = -backgrounds[i].position.z;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (prevCamPos.x - cam.position.x) * parallaxScales[i];
            float targetX = backgrounds[i].position.x + parallax;
            Vector3 targetPos = new Vector3(targetX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPos, smoothing * Time.deltaTime);
        }
        prevCamPos = cam.position;
    }
}
