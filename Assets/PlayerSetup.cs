using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    //public int playerID = 0;
    //int playerCount;
    
    public GameObject[] players;
    //public PlayerSetup playerSetup;

    PlayerMovement movementScript;

    //[SerializeField]
    //Behaviour[] componentsToDisable;
    CharacterController controller;

    Mouse mouse;
    AudioListener audioListener;
    Camera camera;
    gun gun;

    CharacterController thisController;
    PlayerMovement thisMovement;
    Mouse thisMouse;
    Camera thisCamera;
    AudioListener thisAudioListener;
    gun thisGun;

    int previousNumberOfPlayers = 0;
    int numberOfPlayers = 0;

    private void Start()
    {



        thisController = this.GetComponent<CharacterController>();
        thisMovement = this.GetComponent<PlayerMovement>();
        thisMouse = this.GetComponentInChildren<Mouse>();
        thisCamera = this.GetComponentInChildren<Camera>();
        thisAudioListener = this.GetComponentInChildren<AudioListener>();
        //thisGun = this.GetComponentInChildren<gun>();


        thisController.enabled = true;
        thisMovement.enabled = true;
        thisMouse.enabled = true;
        thisCamera.enabled = true;
        thisAudioListener.enabled = true;
        //thisGun.enabled = true;
    }

    private void Update()
    {
        scanForOtherPlayers();
    }

    void scanForOtherPlayers() {
        previousNumberOfPlayers = numberOfPlayers;
        players = GameObject.FindGameObjectsWithTag("Player");
        numberOfPlayers = players.Length;
        if (numberOfPlayers != previousNumberOfPlayers) {
            disableStuff();
        }
    }

    void disableStuff() {
        foreach (GameObject player in players)
        {
            controller = player.GetComponent<CharacterController>();
            movementScript = player.GetComponent<PlayerMovement>();
            camera = player.GetComponentInChildren<Camera>();
            mouse = camera.GetComponent<Mouse>();
            audioListener = camera.GetComponent<AudioListener>();
            //gun = camera.GetComponent<gun>();


            controller.enabled = false;
            movementScript.enabled = false;
            mouse.enabled = false;
            camera.enabled = false;
            audioListener.enabled = false;
            //gun.enabled = false;
        }

        
        thisController.enabled = true;
        thisMovement.enabled = true;
        thisMouse.enabled = true;
        thisCamera.enabled = true;
        thisAudioListener.enabled = true;
        //thisGun.enabled = true;
        
    }

    

}
