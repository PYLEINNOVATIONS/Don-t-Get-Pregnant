using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

	public GameObject nozzle;
	public GameObject bullet;
	//private Vector2 nozzlePos;
	private Vector3 nozzlePos;
	public float speed;
	public float lapse;

	// Use this for initialization
	void Start () {
		//nozzlePos = new Vector2 (nozzle.transform.position.x, nozzle.transform.position.y);
		nozzlePos = new Vector3 (nozzle.transform.position.x, nozzle.transform.position.y, Camera.main.nearClipPlane);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetMouseButtonDown(0)){
			//Vector3 position = new Vector3();
			Vector3 mouseLoc = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			//Vector3 mouseLoc = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition.x), Camera.main.ScreenToWorldPoint(Input.mousePosition.y), 0);
			Debug.Log("Mouse X = " + mouseLoc.x);
			Debug.Log("Mouse Y = " + mouseLoc.y);
			Instantiate(bullet, nozzlePos, Quaternion.identity);
			bullet.GetComponent<Rigidbody>().AddForce(mouseLoc * 1000);
		*/
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10))); //Camera.main.nearClipPlane
			//Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
			Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10)); //Camera.main.nearClipPlane
			//Vector2 myPos = new Vector2(transform.position.x,transform.position.y + 1);
			//Vector2 direction = target - nozzlePos;
			Vector3 direction = target - nozzlePos;
			direction.Normalize();
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			GameObject projectile = (GameObject) Instantiate(bullet, nozzlePos, rotation);
			projectile.GetComponent<Rigidbody>().velocity = direction * speed;
			Object.Destroy (projectile, lapse);
		}
	}
}
