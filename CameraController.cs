using UnityEngine; 
using System.Collections; 

public class CameraController : MonoBehaviour { 
	public PlayerStateController.playerStates currentPlayerState = PlayerStateController.playerStates.idle; 
	public GameObject playerObject = null; 
	public float cameraTrackingSpeed = 0.2f; 
	private Vector3 lastTargetPosition = Vector3.zero; 
	private Vector3 currTargetPosition = Vector3.zero; 
	private float currLerpDistance = 0.0f; 



	void Start()    { //Set the initial camera positioning to prevent any weird jerking //around        
		Vector3 playerPos = playerObject.transform.position;        
		Vector3 cameraPos = transform.position;        
		Vector3 startTargPos = playerPos;        //Set the Z to the same as the camera so it does not move        
		startTargPos.z = cameraPos.z;        
		lastTargetPosition = startTargPos;        
		currTargetPosition = startTargPos;        
		currLerpDistance = 1.0f;    
	}

	void OnEnable(){

		PlayerStateController.onStateChange += onPlayerStateChange; 

	}

	void OnDisable()    {        
		PlayerStateController.onStateChange -= onPlayerStateChange;    
	} 

	void onPlayerStateChange(PlayerStateController.playerStates newState )    
	{        currentPlayerState = newState;    
	}        

	void LateUpdate()    { // Update based on our current state        
		onStateCycle();        // Continue moving to the current target position        
		currLerpDistance += cameraTrackingSpeed;        
		transform.position = Vector3.Lerp(lastTargetPosition, currTargetPosition, currLerpDistance);    
	} 



	// Every cycle of the engine, process the current state    
	void onStateCycle()    { 
		/*We use the player state to determine the current action that the camera should take. Notice that in most cases we are tracking the player - however, in the case of killing or resurrecting, we don't  want to track the player.*/

	switch(currentPlayerState)       
		{            
		
		case PlayerStateController.playerStates.idle:                
		trackPlayer();            
		break;                        
		
		case PlayerStateController.playerStates.left:                
			trackPlayer();
			break;

		case PlayerStateController.playerStates.right:                
			trackPlayer();            
			break; 

		case PlayerStateController.playerStates.firingWeapon:
			break;  

		}
	}

	void trackPlayer()
	{

		Vector3 currCamPos = transform.position;
		Vector3 currPlayerPos = playerObject.transform.position;

		if(currCamPos.x == currPlayerPos.x && currCamPos.y == currPlayerPos.y)        
		{ // Positions are the same - tell the camera not to move, then abort.            
			currLerpDistance = 1f;            
			lastTargetPosition = currCamPos;            
			currTargetPosition = currCamPos;            
			return;        
		} 

		currLerpDistance = 0f;

		lastTargetPosition = currCamPos;
		currTargetPosition = currPlayerPos;
		currTargetPosition.z = currCamPos.z;

	}


	void stopTrackingPlayer() {  
		// Set the target positioning to the camera's current position  
		// to stop its movement in its tracks  
		Vector3 currCamPos = transform.position;
		currTargetPosition = currCamPos;  
		lastTargetPosition = currCamPos; 
		currLerpDistance = 1.0f;
	}







}