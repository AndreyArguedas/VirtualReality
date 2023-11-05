using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ChangeAllMaterialsColor : MonoBehaviour
{
    public Color newColor = Color.red; // The color you want to change to
    public float delay = 30.0f; // Delay in seconds

    private float elapsedTime = 0.0f;
    private bool colorChanged = false;
	
	private static ChangeAllMaterialsColor instance;
	private InputAction keyboardAction;
	
	private void Awake()
    {	
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Makes the GameObject persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {	
        // This message will be printed when the game starts
        Debug.Log("Global script is active!");
    }
	
	private void OnEnable()
    {
        // Create an InputAction for the keyboard
        keyboardAction = new InputAction(binding: "<Keyboard>/H");
        keyboardAction.Enable();

        // Subscribe to the "performed" event
        keyboardAction.performed += OnKeyboardInput;
    }
	
	private void OnDisable()
    {
        // Unsubscribe from the event when the object is disabled or destroyed
        keyboardAction.performed -= OnKeyboardInput;
        keyboardAction.Disable();
    }
	
	private void OnKeyboardInput(InputAction.CallbackContext context)
    {
        // Check if the key was pressed
        if (context.performed)
        {
            // Perform your action here
            Debug.Log("H key is pressed using the Input System. Performing action...");
            // Replace the Debug.Log with your actual action.
        }
    }
	
	

    void Update()
    {	
		// Check if the desired delay has passed and the color hasn't been changed yet
        if (!colorChanged && elapsedTime >= delay)
        {
			Debug.Log("Global script will update!");
			// Find the GameObject by its name
			GameObject myObject = GameObject.Find("t-shirt_long_pose_1");
			GameObject myText = GameObject.Find("TextTags01");
            // Get all objects with a renderer component in the scene
            //Renderer[] renderers = FindObjectsOfType<Renderer>();

            // Iterate through all the renderers and change their materials' color
            /*foreach (Renderer renderer in renderers)
            {
                Material[] materials = renderer.materials;
                foreach (Material material in materials)
                {
                    material.color = newColor;
                }
            }*/
			myObject.GetComponent<Renderer>().material.color = newColor;
			myText.GetComponent<TextMeshPro>().text = "Brand: Roxy \n Price: $60";

            colorChanged = true; // Mark that the color has been changed
        }

        elapsedTime += Time.deltaTime; // Update the elapsed time
    }
}