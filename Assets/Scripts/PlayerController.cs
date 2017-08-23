using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

[RequireComponent (typeof(GunController))]
public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody myRigidbody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;
	// Use this for initialization
	private Camera mainCamera;

	public GunController theGun;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            theGun.isFiring = true;
            StartCoroutine(GetText());

        }
           
        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;
    }

    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:8080/v1/helloworld");
        yield return www.Send();
 
        Debug.Log(www.downloadHandler.text);

    }
}
