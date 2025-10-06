using TMPro;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] public GameObject tealGO;
    [SerializeField] public GameObject pinkGO;
    [SerializeField] public GameObject winGO;

    [SerializeField] static public int count;
    [SerializeField] static public int count2;
    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;

    public void Move(InputAction.CallbackContext context){
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context){
        if (context.performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void Awake(){
        controller = GetComponent<CharacterController>();
        pinkGO=GameObject.Find("Count 2");
        tealGO=GameObject.Find("Count");
        winGO=GameObject.Find("WIN");
        count = 0;
        count2 = 0;
        SetCountText();
    }

    void Update(){
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
	SetCountText();

        if (count == 4){
            winGO.GetComponent<TextMeshProUGUI>().text=$"Teal WIN!!!";
            winGO.SetActive(true);
        } else if (count2 == 4){
            winGO.GetComponent<TextMeshProUGUI>().text=$"Pink WIN!!!";
            winGO.SetActive(true);
        }
    }

    void SetCountText() {
        pinkGO.GetComponent<TextMeshProUGUI>().text= "Count: " + count2.ToString();
        tealGO.GetComponent<TextMeshProUGUI>().text= "Count: " + count.ToString();
    }
}


