using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollingScript : MonoBehaviour {

    public Vector2 speed = new Vector2(2, 2);
    public Vector2 direction = new Vector2(-1, 0);
    public bool isLinkedToCamera = false;
    bool isLooping = false;
    private List<Transform> backgroundPart;

	// Use this for initialization
	void Start () {
        if (isLooping)
        {
            backgroundPart = new List<Transform>();
            for(int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if(child.GetComponent<Renderer>() != null)
                {
                    backgroundPart.Add(child);
                }
            }

            //backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }
	}
}
