using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;

public class ChangeAllMaterialsColor : MonoBehaviour
{
	private static ChangeAllMaterialsColor instance;
	private InputAction keyboardAction;
	private GameObject[] parentObjects;
	private Dictionary<GameObject, Color> objectHeatMap;
	private Dictionary<Renderer, Color> objectHeatMapRenderersReset;
	public GameObject heatMapImage1;
	public GameObject heatMapImage2;
	
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
		objectHeatMap = new Dictionary<GameObject, Color>();
		// Add GameObjects and their colors to the dictionary
        objectHeatMap.Add(GameObject.Find("enterManequin1"), Color.green);
        objectHeatMap.Add(GameObject.Find("enterManequin2"), Color.red);
        objectHeatMap.Add(GameObject.Find("enterManequin3"), Color.blue);
        objectHeatMap.Add(GameObject.Find("enterManequin4"), Color.blue);
		objectHeatMap.Add(GameObject.Find("enterManequin5"), Color.red);
        objectHeatMap.Add(GameObject.Find("enterManequin6"), Color.green);
        objectHeatMap.Add(GameObject.Find("enterManequin7"), Color.red);
        objectHeatMap.Add(GameObject.Find("enterManequin8"), Color.yellow);
		objectHeatMap.Add(GameObject.Find("enterManequin9"), Color.blue);
        objectHeatMap.Add(GameObject.Find("enterManequin10"), Color.red);
        objectHeatMap.Add(GameObject.Find("enterManequin11"), Color.green);
		// Add GameObjects and their colors to the dictionary
        objectHeatMap.Add(GameObject.Find("bag1_1"), Color.green);
        objectHeatMap.Add(GameObject.Find("bag1_2"), Color.red);
        objectHeatMap.Add(GameObject.Find("bag1_3"), Color.blue);
        objectHeatMap.Add(GameObject.Find("bag1_4"), Color.blue);
		objectHeatMap.Add(GameObject.Find("bag1_5"), Color.red);
        objectHeatMap.Add(GameObject.Find("bag1_6"), Color.green);
        objectHeatMap.Add(GameObject.Find("bag1_7"), Color.red);
        objectHeatMap.Add(GameObject.Find("bag1_8"), Color.yellow);
		objectHeatMap.Add(GameObject.Find("bag1_9"), Color.blue);
		objectHeatMapRenderersReset = new Dictionary<Renderer, Color>();
		
		heatMapImage1 = GameObject.Find("heatMapImage1");
		heatMapImage1.SetActive(false);
		
		heatMapImage2 = GameObject.Find("heatMapImage2");
		heatMapImage2.SetActive(false);
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
		
        // Check if the key was pressed
        if (context.performed)
        {
			 switch (key)
        {
            case "h":
				//createHeatMap(parentObjects);
				heatMapImage1.SetActive(true);
				heatMapImage2.SetActive(true);
				createHeatMap(objectHeatMap);
                Debug.Log("H key is pressed. Performing action for 'H'...");
                // Replace the Debug.Log with your actual 'H' key action.
                break;
            case "k":
				heatMapImage1.SetActive(false);
				heatMapImage2.SetActive(false);
				resetHeatMap(objectHeatMapRenderersReset);
				
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
	
	
	void createHeatMap(Dictionary<GameObject, Color> objects){
		
		foreach (var kvp in objects)
        {
            GameObject obj = kvp.Key;
            Color color = kvp.Value;
			
            // Get all the child GameObjects of the current parentObject
            Transform[] childTransforms = obj.GetComponentsInChildren<Transform>();

            foreach (Transform childTransform in childTransforms)
            {
                Renderer childRenderer = childTransform.GetComponent<Renderer>();

                if (childRenderer != null)
                {
					if(!objectHeatMapRenderersReset.ContainsKey(childRenderer)){
						objectHeatMapRenderersReset.Add(childRenderer, childRenderer.material.color);
					}
                    // Change the material color of the child GameObject
                    childRenderer.material.color = color;
                }

            }
        }
    }
	
	void resetHeatMap(Dictionary<Renderer, Color> objects){
		
		foreach (var kvp in objects)
        {
            Renderer obj = kvp.Key;
            Color color = kvp.Value;
			
			obj.material.color = color;
			
			
			//UnityEditor.PrefabUtility.RevertObjectOverride(obj, InteractionMode.UserAction);
			//UnityEditor.PrefabUtility.RevertObjectOverride(this.gameObject, InteractionMode.AutomatedAction);
			
            /* // Get all the child GameObjects of the current parentObject
            Transform[] childTransforms = obj.GetComponentsInChildren<Transform>();

            foreach (Transform childTransform in childTransforms)
            {
                Renderer childRenderer = childTransform.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    // Change the material color of the child GameObject
                    childRenderer.material.color = color;
                }

            } */
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