using UnityEngine;

public class RotateBanan : MonoBehaviour{
    private bool isTouch;

    void OnTriggerEnter(Collider other) {
    	if (other.gameObject.tag == "Pink"){
		    PlayerController.count2 = PlayerController.count2 + 1;	
            isTouch = true;
	    }else if(other.gameObject.tag == "Teal"){
            PlayerController.count = PlayerController.count + 1;
            isTouch = true;
        }    	
    }

    void Update () {
    transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        if(isTouch){
            this.gameObject.SetActive(false);
        }
    }
}
