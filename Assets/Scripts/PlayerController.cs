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
    //void Start () {
    //		myRigidbody = GetComponent<Rigidbody>();
    //		mainCamera = FindObjectOfType<Camera>();
    //}

    // Update is called once per frame
    //void Update () {
    //	moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical"));
    //	moveVelocity = moveInput * moveSpeed;

    //	Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
    //	Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
    //	float rayLength;

    //	if(groundPlane.Raycast(cameraRay, out rayLength)){
    //		Vector3 pointToLook = cameraRay.GetPoint(rayLength);
    //		Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
    //		transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
    //	}
    //	if (Input.GetMouseButtonDown(0))
    //		theGun.isFiring = true;

    //	if(Input.GetMouseButtonUp(0))
    //		theGun.isFiring = false;


    //}
    //void FixedUpdate(){
    //	myRigidbody.velocity = moveVelocity;
    //}

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
