using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour {
    private Rigidbody body;
    [SerializeField] string key;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), key))) {
            body.useGravity = true;
        }
    }
}
