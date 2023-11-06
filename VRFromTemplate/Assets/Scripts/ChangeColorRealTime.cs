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
	private GameObject[] parentObjects;
	
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
		parentObjects = new GameObject[]
        {
            GameObject.Find("SM_Manequin_1 Variant 4"),
			GameObject.Find("SM_Manequin_2 Variant"),
			GameObject.Find("dress3_hanger Variant (1)"),
			GameObject.Find("dress3_hanger Variant (2)"),
			GameObject.Find("dress3_hanger Variant (3)"),
			GameObject.Find("dress3_hanger Variant (4)"),
			GameObject.Find("SM_Manequin_2 Variant 4"),
			GameObject.Find("SM_Manequin_3 Variant"),
			GameObject.Find("SM_Manequin_1 Variant 1"),
			GameObject.Find("SM_Manequin_2 Variant 1 (2)"),
			GameObject.Find("SM_Manequin_1 Variant 5"),
			GameObject.Find("SM_Manequin_2 Variant 1 (1)"),
			GameObject.Find("SM_Manequin_3 Variant 3"),
			GameObject.Find("SM_Manequin_1 Variant"),
			GameObject.Find("SM_Manequin_2 Variant 1"),
			GameObject.Find("bag_2"),
			GameObject.Find("bag_3"),
			GameObject.Find("bag_1"),
			GameObject.Find("bag_4"),
			GameObject.Find("bag_1 (1)"),
			GameObject.Find("bag_4 (1)"),
			GameObject.Find("bag_3 (1)"),
			GameObject.Find("bag_2 (1)"),
			GameObject.Find("bag_3 (2)"),
        };
    }
	
	private void OnEnable()
    {
        // Create an InputAction for the keyboard
        keyboardAction = new InputAction(binding: "<Keyboard>/H");
        keyboardAction.Enable();
		keyboardAction.AddBinding("<Keyboard>/K");
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
		// Get the key that was pressed
        string key = context.control.name;
		//Debug.Log(key + " is pressed using the context.control.name...");

		
        // Check if the key was pressed
        if (context.performed)
        {
			 switch (key)
        {
            case "h":
				createHeatMap(parentObjects);
                Debug.Log("H key is pressed. Performing action for 'H'...");
                // Replace the Debug.Log with your actual 'H' key action.
                break;
            case "k":
				
				GameObject.Find("SM_Manequin_1 Variant 4").GetComponent<Renderer>().material.color = Color.gray;
                Debug.Log("K key is pressed. Performing action for 'K'...");
                // Replace the Debug.Log with your actual 'K' key action.
                break;
            // Add more cases for other keys as needed
            default:
                Debug.Log($"Key '{key}' is pressed. Performing a default action...");
                // Replace the Debug.Log with a default action or leave it empty.
                break;
        }
        }
    }
	
	void createHeatMap(GameObject[] objects){
		// Iterate through the array of parent GameObjects
        foreach (GameObject parentObject in objects)
        {
            // Get all the child GameObjects of the current parentObject
            Transform[] childTransforms = parentObject.GetComponentsInChildren<Transform>();
			Debug.Log($"childTransform '{childTransforms}'");
            // Iterate through all child transforms (including the parent itself)
            foreach (Transform childTransform in childTransforms)
            {
				Debug.Log($"childTransform '{childTransform}'");
                // Check if the current transform is not the same as the parent transform
                /*if (childTransform != parentObject.transform)
                {*/
                    // Get the Renderer component of the child GameObject
                    Renderer childRenderer = childTransform.GetComponent<Renderer>();

                    if (childRenderer != null)
                    {
						Debug.Log($"childRenderer '{childRenderer}'");
                        // Change the material color of the child GameObject
						Debug.Log($"childRenderer color before '{childRenderer.material.color}'");
                        childRenderer.material.color = Color.red;
						Debug.Log($"childRenderer color after '{childRenderer.material.color}'");
                    }
                //}
            }
        }
		
	}
	
	

    void Update()
    {	
		// // Check if the desired delay has passed and the color hasn't been changed yet
        // if (!colorChanged && elapsedTime >= delay)
        // {
			// Debug.Log("Global script will update!");
			// // Find the GameObject by its name
			// GameObject myObject = GameObject.Find("t-shirt_long_pose_1");
			// GameObject myText = GameObject.Find("TextTags01");
            // // Get all objects with a renderer component in the scene
            // //Renderer[] renderers = FindObjectsOfType<Renderer>();

            // // Iterate through all the renderers and change their materials' color
            // /*foreach (Renderer renderer in renderers)
            // {
                // Material[] materials = renderer.materials;
                // foreach (Material material in materials)
                // {
                    // material.color = newColor;
                // }
            // }*/
			// myObject.GetComponent<Renderer>().material.color = newColor;
			// myText.GetComponent<TextMeshPro>().text = "Brand: Roxy \n Price: $60";

            // colorChanged = true; // Mark that the color has been changed
        // }

        // elapsedTime += Time.deltaTime; // Update the elapsed time
    }
}