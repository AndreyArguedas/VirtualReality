using UnityEngine;

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
		// Check if the desired delay has passed and the color hasn't been changed yet
        if (!colorChanged && elapsedTime >= delay)
        {
			Debug.Log("Global script will update!");
            // Get all objects with a renderer component in the scene
            Renderer[] renderers = FindObjectsOfType<Renderer>();

            // Iterate through all the renderers and change their materials' color
            foreach (Renderer renderer in renderers)
            {
                Material[] materials = renderer.materials;
                foreach (Material material in materials)
                {
                    material.color = newColor;
                }
            }

            colorChanged = true; // Mark that the color has been changed
        }

        elapsedTime += Time.deltaTime; // Update the elapsed time
    }
}