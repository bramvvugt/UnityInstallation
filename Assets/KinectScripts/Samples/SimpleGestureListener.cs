using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;
	
	// private bool to track if progress message has been displayed
	private bool progressDisplayed;

    Animator animator;
    public GameObject Tree;
    public GameObject Gekkeboom;
    public GameObject Flower;
    public GameObject Bosje;
    public GameObject butterfly;
    public GameObject bird;
    public Transform TreeGrow;
    public GameObject light;

    public GameObject center;
    Vector3 centerdetect;
    bool standstill = false;

    public Text welkom;
    public Text uitleg;

    public AudioClip brid;

    AudioSource audioData;
    public Camera cam;

    int plantcounter = -1;

    public GameObject[] Plants;

    float counter = 0f;
    float duration = 2f;
    public bool lighting = false;

    public List<GameObject> plants = new List<GameObject>();


    //Color color1 = new Color32(53, 66, 115, 5);
    //Color color2 = new Color32(66, 182, 255, 5);


    Light lt;


    public void Start()
    {
        welkom.text = "Sta jij wel eens stil bij de natuur?";
        lt = light.GetComponent<Light>();
       
       // Instantiate(Tree, positionTree, Quaternion.identity);
        animator = Tree.GetComponent<Animator>();
        // animator.SetBool("Grow", true);

        //SpawnTree();
        audioData = GetComponent<AudioSource>();
        cam = cam.GetComponent<Camera>();

        //cam.backgroundColor = c1;

        /*for (int i = 0; i < 3; i++)
        {
            Vector3 positionTree = new Vector3(Random.Range(-6.0f, 11.0f), 0.5f, Random.Range(-10.0f, -6.0f));
            Plants[i] = Instantiate(Gekkeboom, positionTree, Quaternion.identity) as GameObject;
            //Instantiate(Gekkeboom, positionTree, Quaternion.identity);
            animator = Plants[i].GetComponent<Animator>();
            animator.SetBool("Grow", true);
        }*/
    }


    IEnumerator fadeInAndOut(Light lightToFade,Camera camerabg, bool fadeIn, float duration)
    {
        float minLuminosity = 1; // min intensity
        float maxLuminosity = 1.5f; // max intensity
        Color color1;
        Color color2;

        Color c1 = new Color32(53, 66, 115, 5);
        Color c2 = new Color32(66, 182, 255, 5);

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;

        if (fadeIn)
        {
            a = minLuminosity;
            b = maxLuminosity;
            color1 = c1;
            color2 = c2;
        }
        else
        {
            a = maxLuminosity;
            b = minLuminosity;
            color1 = c2;
            color2 = c1;
        }

        float currentIntensity = lightToFade.intensity;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            lightToFade.intensity = Mathf.Lerp(a, b, counter / duration);
            camerabg.backgroundColor = Color.Lerp(color1, color2, counter / duration);

            yield return null;
        }
    }

    public void Update()
    {
     if (standstill = false)
        {
            //StartCoroutine("StandStill");
            //  StartCoroutine("StandStill");
        }  
        /* if (lighting && counter < duration) {
             counter += Time.deltaTime;
             lt.intensity = Mathf.Lerp(1, 1.5f, counter / duration);
             cam.backgroundColor = Color.Lerp(color1, color2, counter / duration);
         }
         else if(lighting == false && lt.intensity == 1.5f && counter < duration)
         {
             counter += Time.deltaTime;
             lt.intensity = Mathf.Lerp(1.5f, 1f, counter / duration);
             cam.backgroundColor = Color.Lerp(color2, color1, counter / duration);
         }*/
     
    }
    public void SpawnTree()
    {
        Vector3 positionTree = new Vector3(Random.Range(-13.0f, 12.0f), 0.5f, Random.Range(-6.0f, -4.0f));
        GameObject tree = Instantiate(Gekkeboom, positionTree, Quaternion.identity) as GameObject;
        animator = tree.GetComponent<Animator>();
        animator.SetBool("Grow", true);
        plants.Add(tree);
    }

    public void SpawnFlower()
    {
        Vector3 positionTree = new Vector3(Random.Range(8.0f, -4.0f), 0.3f, Random.Range(-15.0f, -14.0f));
        GameObject flower = Instantiate(Flower, positionTree, Quaternion.identity) as GameObject;
        animator = flower.GetComponent<Animator>();
        animator.SetBool("Grow", true);
        plants.Add(flower);
    }
    public void SpawnBosje()
    {
        Vector3 positionTree = new Vector3(Random.Range(-13.0f, 8f), 0.8f, Random.Range(-12.0f, -10.0f));
        GameObject bosje = Instantiate(Bosje, positionTree, Quaternion.identity) as GameObject;
        animator = bosje.GetComponent<Animator>();
        animator.SetBool("Grow", true);
        plants.Add(bosje);
    }

    public void SpawnButterfly()
    {
        Vector3 bfly = new Vector3(6f, 1f, -14f);
        GameObject Butterfly = Instantiate(butterfly, bfly, transform.rotation * Quaternion.Euler(0f, 270f, 0f)) as GameObject;
      
       // animator = tree.GetComponent<Animator>();
        //animator.SetBool("Grow", true);
        //plants.Add(tree);
    }

    public void SpawnBird()
    {
        Vector3 birdfly = new Vector3(55f, 17f, 14f);
        GameObject Bird = Instantiate(bird, birdfly, transform.rotation * Quaternion.Euler(0f, 270f, 33f)) as GameObject;

        // animator = tree.GetComponent<Animator>();
        //animator.SetBool("Grow", true);
        //plants.Add(tree);
    }
    public IEnumerator StandStill()
    {
        standstill = true;
        centerdetect = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
        // standstill = true;
        yield return new WaitForSeconds(3f); // waits 3 seconds
        if (center.transform.position.x > centerdetect.x -0.1f && center.transform.position.x < centerdetect.x + 0.1f)
        {
            standstill = true;
            Debug.Log("werkt");
            //   sandstill = false;
            uitleg.text = "Ondek de bewegingen om de natuur te laten groeien.";
        }
        else
        {
            
            standstill = false;
            //centerdetect = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
            Debug.Log("werkt niet");
        }
        standstill = false; // will make the update method pick up 
       // Debug.Log("werkt niet");
        Debug.Log(center.transform.position.x);
        Debug.Log(centerdetect.x);
    }

    public void UserDetected(uint userId, int userIndex)
	{
		// as an example - detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

		manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
		manager.DetectGesture(userId, KinectGestures.Gestures.Squat);

        //		manager.DetectGesture(userId, KinectGestures.Gestures.Push);
        //		manager.DetectGesture(userId, KinectGestures.Gestures.Pull);

        //		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeUp);
        //		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeDown);
        //  animator.SetBool("Grow", true);
        StartCoroutine(fadeInAndOut(lt, cam, true, duration));
        Debug.Log(center.transform.position);
        SpawnTree();
        SpawnBird();
        standstill = true;
       // centerdetect = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
        StartCoroutine("StandStill");
        welkom.text = "";

        if (GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = "User detected";
		}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = string.Empty;
            StartCoroutine(fadeInAndOut(lt, cam, false, duration));
            foreach (GameObject Gekkeboom in plants)
            {

                plantcounter++;
                animator = plants[plantcounter].GetComponent<Animator>();
                animator.SetBool("Grow", false);
                audioData.Play(0);
                Debug.Log("started");
                Debug.Log(center.transform.position);
                welkom.text = "Sta jij wel eens stil bij de natuur?";
            }
            
        }

    }

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
        //GestureInfo.guiText.text = string.Format("{0} Progress: {1:F1}%", gesture, (progress * 100));
        if (gesture == KinectGestures.Gestures.RaiseRightHand && progress > 0.3f)
        {
            //GestureInfo.GetComponent<GUIText>().text = "hij is gaande";
         
       
        }

            if (gesture == KinectGestures.Gestures.Click && progress > 0.3f)
		{
			string sGestureText = string.Format ("{0} {1:F1}% complete", gesture, progress * 100);
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}		
		else if((gesture == KinectGestures.Gestures.ZoomOut || gesture == KinectGestures.Gestures.ZoomIn) && progress > 0.5f)
		{
			string sGestureText = string.Format ("{0} detected, zoom={1:F1}%", gesture, screenPos.z * 100);
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}
		else if(gesture == KinectGestures.Gestures.Wheel && progress > 0.5f)
		{
			string sGestureText = string.Format ("{0} detected, angle={1:F1} deg", gesture, screenPos.z);
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}
	}

    public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
    {
        string sGestureText = gesture + " detected";

        uitleg.text = "";

        if (gesture == KinectGestures.Gestures.Wave)
        {
            SpawnButterfly();
            // animator.SetBool("Grow", false);
            Debug.Log("false");
        }

        if (gesture == KinectGestures.Gestures.RaiseRightHand)
        {
            Debug.Log("Boom");
            SpawnTree();
        }

        if (gesture == KinectGestures.Gestures.RaiseLeftHand)
        {
            Debug.Log("Boom");
            SpawnFlower();
        }

        if (gesture == KinectGestures.Gestures.SwipeUp)
        {
            Debug.Log("Boom");
            SpawnBosje();
        }

        if (gesture == KinectGestures.Gestures.Click)
			sGestureText += string.Format(" at ({0:F1}, {1:F1})", screenPos.x, screenPos.y);
		
		if(GestureInfo != null)
			GestureInfo.GetComponent<GUIText>().text = sGestureText;


        progressDisplayed = false;
       
            return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		if(progressDisplayed)
		{
			// clear the progress info
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = String.Empty;
			
			progressDisplayed = false;
		}
		
		return true;
	}
	
}
