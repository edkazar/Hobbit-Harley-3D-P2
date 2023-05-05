using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
	[SerializeField] Transform wheel1;
	[SerializeField] Transform wheel2;
	
	[SerializeField] public float movementSpeed = 1.0f;
	[SerializeField] float rotateSpeed = 1.0f;
	[SerializeField] private Vector3 TurnSpeed;

	public int currentTargetPos;

    private List<Transform> WayPoints;
	public ButtonManager buttonManager;
    public Quiz3 q3;

    public GameObject quiz3;
	public GameObject quiz6;

	public bool hasCrossed = false;
    public bool fulfilledTest = false;
    public bool startTest = false;

    private UITaskController myUIController;

    private bool experienceDone = false;

    // Start is called before the first frame update
    void Start()
    {

        

		WayPoints = new List<Transform>();
        WayPoints.Add(GameObject.Find("WayPoint2").transform);
        WayPoints.Add(GameObject.Find("WayPoint3").transform);
        WayPoints.Add(GameObject.Find("WayPoint4").transform);
        WayPoints.Add(GameObject.Find("WayPoint5").transform);
        WayPoints.Add(GameObject.Find("WayPoint6").transform);
		WayPoints.Add(GameObject.Find("WayPoint7").transform);
		WayPoints.Add(GameObject.Find("WayPoint8").transform);
		WayPoints.Add(GameObject.Find("WayPoint9").transform);
		WayPoints.Add(GameObject.Find("WayPoint10").transform);
		WayPoints.Add(GameObject.Find("WayPoint11").transform);
        WayPoints.Add(GameObject.Find("WayPoint12").transform);
        WayPoints.Add(GameObject.Find("WayPoint13").transform);

        currentTargetPos = 0;
        

        GameObject UIController = GameObject.Find("UI_Checklist");
        myUIController = UIController.GetComponent<UITaskController>();
    }

    // Update is called once per frame
    void Update()
    {
        //updateTurning();
        if(!experienceDone)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime);
        }

        updateWheelRotate();
        
		updateTargetPosition();
    }

    void updateTurning()
    {
        
        if(playerTransform.position == WayPoints[0].position)
        {
			//playerTransform.rotation = WayPoints[currentTargetPos].rotation;
			playerTransform.position = Vector3.MoveTowards(playerTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime);
			buttonManager.Quiz1();
            if (playerTransform.rotation != WayPoints[1].rotation)
            {
				playerTransform.Rotate(TurnSpeed * Time.deltaTime);
				
			}
            else
            {
				playerTransform.Translate(rotateSpeed * 0.1f * Time.deltaTime, 0f, 0f);
			}

            
            buttonManager.Quiz1();
		}
		
        else if (playerTransform.position == WayPoints[0].position)
        {
			
		}

		else
		{
			playerTransform.position = Vector3.MoveTowards(playerTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime);
		}
       
	}
    void updateWheelRotate()
    {
		if (playerTransform.position != WayPoints[currentTargetPos].position)
		{
			wheel1.Rotate(360 * rotateSpeed * Time.deltaTime, 0, 0);
			wheel2.Rotate(360 * rotateSpeed * Time.deltaTime, 0, 0);
		}
        
	}
    void updateTargetPosition()
    {
        if (playerTransform.position == WayPoints[currentTargetPos].position)
        {
            
            if (playerTransform.position == WayPoints[3].position )
            {
				Time.timeScale = 0f;
				quiz3.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);

				
			}
			if (playerTransform.position == WayPoints[7].position)
			{
				Time.timeScale = 0f;
				quiz6.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);


			}
			currentTargetPos++;
            /*if (fulfilledTest)
            {
                if (currentTargetPos < WayPoints.Count - 1)
                {
                    currentTargetPos++;
                    fulfilledTest = false;
                }
            }
            else
            {
                startTest = true;
                if (!myUIController.ongoingTest && currentTargetPos != 2 && currentTargetPos < 4)
                {
                    myUIController.showObjectives();
                    myUIController.ongoingTest = true;
                }
            }*/
        }

        if (playerTransform.position == WayPoints[11].position)
        {
            experienceDone = true;
        }
    }

    public void setStartTestFalse()
    {
        startTest = false;
        fulfilledTest = true;
        myUIController.ongoingTest = false;
    }

    public int getWaypointsLength()
    {
        return WayPoints.Count;
    }

    public bool getExperienceDone()
    {
        return experienceDone;
    }

    public void timeContinue()
    {
		Time.timeScale = 1f;
		currentTargetPos++;
	}
}
