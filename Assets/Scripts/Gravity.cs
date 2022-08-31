using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using DG.Tweening;


public class Gravity : MonoBehaviour
{
    public XRIDefaultInputActions controlls;
    public Camera mainCamera;
    public GameObject cameraOffset;
    public RawImage fadeImage;
    public string currentState;
    public float speed;
    public Text guideText;
    public Text directionText;
    public Text currentDireText;
    private Rigidbody rb;
    private float cameraZ;
    private float cameraY;
    private float cameraX;
    private bool token;
    private Vector3 startPostion;


    private void Awake() {
        if(controlls == null){
            controlls = new XRIDefaultInputActions();
        }
    }
    private void OnEnable() {
        controlls.XRILeftHand.Enable();
    }
    private void OnDisable() {
        controlls.XRILeftHand.Disable();
    }

    private void Start() {
        rb = GetComponent<Rigidbody>();
        currentState = "bottom";
        cameraOffset.transform.rotation = Quaternion.Euler(0, 0, 0);
        controlls.XRILeftHand.ChangeGravity.started += SwitchGravity;
        token = false;
        fadeImage.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        fadeImage.color = Color.clear;
    }
    
    private void Update() {
        cameraX = mainCamera.transform.rotation.eulerAngles.x;
        cameraY = mainCamera.transform.rotation.eulerAngles.y;
        cameraZ = mainCamera.transform.rotation.eulerAngles.z;
        // Debug.Log("cameraX:"+cameraX+" "+"cameraY:"+cameraY+" "+"cameraZ"+cameraZ);
    }
    private void FixedUpdate() {
        switch(currentState){
            case "bottom":
            rb.AddForce(0, -9.8f, 0);
            UpDownGravity();
            UpDownUI();
            currentDireText.color = Color.red;
            currentDireText.text = "bottom"; 
            break;
            case "right":
            SideGravity();
            rb.AddForce(9.8f, 0, 0);
            SideUI();
            currentDireText.color = Color.green;
            currentDireText.text = "right"; 
            break;
            case "left":
            rb.AddForce(-9.8f, 0, 0);
            SideGravity();
            SideUI();
            currentDireText.color = Color.blue;
            currentDireText.text = "left"; 
            break;
            case "top":
            rb.AddForce(0, 9.8f, 0);
            UpDownGravity();
            UpDownUI();
            currentDireText.color = Color.yellow;
            currentDireText.text = "top"; 
            break;
        }
        token = false;
    }
    private void SwitchGravity(InputAction.CallbackContext context){
        Debug.Log("Switch!");
        token = true;
    }
    void UpDownUI(){
        if(cameraY > 75 && cameraY < 105){
            directionText.color = Color.green;
            directionText.text = "right"; 
            ShowGuide();
        }
        else if(cameraY > 255 && cameraY < 285){
            directionText.color = Color.blue;
            directionText.text = "left"; 
            ShowGuide();
        }
        else if(currentState == "bottom" && cameraX > 240 && cameraX < 300){
            directionText.color = Color.yellow;
            directionText.text = "top"; 
            ShowGuide();
        }
            
        else if(currentState == "top" && cameraX > 75 && cameraX < 120){
            directionText.color = Color.red;
            directionText.text = "bottom"; 
            ShowGuide();
        }
        else{
            FadeGuide();
        }
    }
    void SideUI(){
        if(((cameraX > 345 && cameraX <= 360) || (cameraX < 15 && cameraX >= 0)) && ((cameraZ > 345 && cameraZ <= 360) || (cameraZ < 15 && cameraZ >= 0))){
            directionText.color = Color.red;
            directionText.text = "bottom"; 
            ShowGuide();
        }
        else if((cameraX > 345 && cameraX <= 360) || (cameraX < 15 && cameraX >= 0)){
            if(currentState == "left" && cameraY > 150 && cameraY < 210){
                directionText.color = Color.green;
                directionText.text = "right"; 
                ShowGuide();
            }
            else if(currentState == "right" && cameraY > 150 && cameraY < 210){
                directionText.color = Color.blue;
                directionText.text = "left"; 
                ShowGuide();
            }
            else{
                FadeGuide();
            }
        }
        else if(cameraX > 240 && cameraX < 300){
            directionText.color = Color.yellow;
            directionText.text = "top"; 
            ShowGuide();
        }
        else{
            FadeGuide();
        }
    }
    void ShowGuide(){
        guideText.DOFade(1, 0.3f);
        directionText.DOFade(1, 0.3f);
    }
    void FadeGuide(){
        guideText.DOFade(0, 0.3f);
        directionText.DOFade(0, 0.3f);
    }
    void UpDownGravity(){
        if(token){
            if(cameraY > 75 && cameraY < 105){
                Blink();
                Invoke(nameof(TurnRight), 0.4f);
            }
            else if(cameraY > 255 && cameraY < 285){
                Blink();
                Invoke(nameof(TurnLeft), 0.4f);
            }
            else if(currentState == "bottom" && cameraX > 240 && cameraX < 300){
                Blink();
                Invoke(nameof(TurnTop), 0.4f);
                }
            
            else if(currentState == "top" && cameraX > 75 && cameraX < 120){
                Blink();
                Invoke(nameof(TurnBottom), 0.4f);
            }
            
            token = false;
        }
    }
    
    void SideGravity(){
        if(token){
            if(((cameraX > 345 && cameraX <= 360) || (cameraX < 15 && cameraX >= 0)) && ((cameraZ > 345 && cameraZ <= 360) || (cameraZ < 15 && cameraZ >= 0))){
                Blink();
                Invoke(nameof(TurnBottom), 0.4f);
            }
            else if((cameraX > 345 && cameraX <= 360) || (cameraX < 15 && cameraX >= 0)){
                if(currentState == "left" && cameraY > 150 && cameraY < 210){
                    Blink();
                    Invoke(nameof(TurnRight), 0.4f);
                }
                else if(currentState == "right" && cameraY > 150 && cameraY < 210){
                    Invoke(nameof(TurnLeft), 0.4f);
                    Blink();

                }
            }
            else if(cameraX > 240 && cameraX < 300){
                Blink();
                Invoke(nameof(TurnTop), 0.4f);
            }
            token = false;
        }
    }

    void TurnLeft(){
        startPostion = transform.position;
        Debug.Log("left");
        currentState = "left";
        cameraOffset.transform.localRotation = Quaternion.Euler(-90, 90, 0);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        

    }
    void TurnRight(){
        startPostion = transform.position;
        Debug.Log("right");
        currentState = "right";
        cameraOffset.transform.localRotation = Quaternion.Euler(-90, -90, 0);
        transform.rotation = Quaternion.Euler(0, 0, 90);
    
    }
    void TurnBottom(){
        startPostion = transform.position;
        Debug.Log("bottm");
        currentState = "bottom";
        cameraOffset.transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);

        
    }
    void TurnTop(){
        startPostion = transform.position;
        Debug.Log("top");
        currentState = "top";
        cameraOffset.transform.localRotation = Quaternion.Euler(-90, 0, -180);
        transform.rotation = Quaternion.Euler(0, 0, 180);

    }
    public void Blink(){
        fadeImage.DOColor(Color.black, 0.3f);
        Invoke(nameof(FadeOut), 0.5f);
    }
    void FadeOut(){
        fadeImage.DOColor(Color.clear, 0.3f);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Breakable"){
            if((transform.position - startPostion).magnitude > 8){
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.tag == "Untagged"){
            startPostion = transform.position;
        }
    }
}
