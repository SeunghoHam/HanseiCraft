using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Transform tf_Crosshair;
    float camPosX;
    float camPosZ;
    float mouseSensitiveX = 0.1f;
    float mouseSensitiveY = 0.06f;
    public  Camera camera;

    void Awake()
    {
        camera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairMoving();
        ViewMoving();
    }

    void ViewMoving()
    {
        camera.transform.position = new Vector3(camPosX, camera.transform.position.y, camPosZ);
        if(tf_Crosshair.localPosition.x > (Screen.width/ 2 - 100))
        {
            camPosX += mouseSensitiveX;
        }
        else if(tf_Crosshair.localPosition.x < (-Screen.width / 2 + 100))
        {
            camPosX -= mouseSensitiveX;
        }

        if(tf_Crosshair.localPosition.y > (Screen.height /2 - 50))
        {
            camPosZ += mouseSensitiveY;
        }
        else if (tf_Crosshair.localPosition.y < (-Screen.height / 2 + 50))
        {
            camPosZ -= mouseSensitiveY;
        }
    }
    void CrosshairMoving()
    {
        tf_Crosshair.localPosition = new Vector2(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2));

        float t_cursorPosX = tf_Crosshair.localPosition.x;
        float t_cursorPosY = tf_Crosshair.localPosition.y;

        t_cursorPosX = Mathf.Clamp(t_cursorPosX, (-Screen.width / 2 + 50), (Screen.width / 2 - 50));
        t_cursorPosY = Mathf.Clamp(t_cursorPosY, (-Screen.height / 2 + 30), (Screen.height / 2 - 30));


        tf_Crosshair.localPosition = new Vector2(t_cursorPosX, t_cursorPosY);

    }
}
