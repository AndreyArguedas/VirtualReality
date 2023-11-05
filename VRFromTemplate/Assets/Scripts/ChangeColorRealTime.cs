using UnityEngine;
using TMPro;

public class ChangeAllMaterialsColor : MonoBehaviour
{
    public Color newColor = Color.red; // The color you want to change to
    public float delay = 30.0f; // Delay in seconds

    private float elapsedTime = 0.0f;
    private bool colorChanged = false;
	
	private static ChangeAllMaterialsColor instance;
	
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

    void Update()
    {	
		// Start genetaring the Heat Map
        /*if (Input.GetKeyDown(KeyCode.H))
        {
            // Perform your action here
            Debug.Log("H key is pressed. Performing action...");
            // You can replace the Debug.Log with your actual action.
        }*/
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