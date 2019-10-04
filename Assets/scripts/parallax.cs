using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform[] background;
    private float[] parallaxSpeed;
    [SerializeField]
    private float smoothing = 1f;
    private Transform cam;
    private  Vector3 prevCampPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        prevCampPos = cam.position;

        parallaxSpeed = new float[background.Length];
        for (int i = 0; i < background.Length; i++)
        {
            parallaxSpeed[i] = background[i].position.z * -1;
        }


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < background.Length; i++)
        {
            float parallax = (prevCampPos.x - cam.position.x) * parallaxSpeed[i];
            float targetPosX = background[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(targetPosX, background[i].position.y, background[i].position.z);
            background[i].position = Vector3.Lerp(background[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        prevCampPos = cam.position;
    }
}
