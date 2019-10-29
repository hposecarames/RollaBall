using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
   public float speed;
   public Text countText;
   public Text winText;
   private Rigidbody jugador;
   private int count;

   void Start() {
      jugador = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
      winText.text = "";
   }
   void FixedUpdate() {
      
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
      jugador.AddForce (movement * speed);
   }
   void OnTriggerEnter(Collider other) {

      if(other.gameObject.CompareTag("Pick Up")){
         other.gameObject.SetActive(false);
         count = count +10;
         SetCountText();

      }  
      if (other.gameObject.tag == "Enemigo")
        {
            countText.text = "Ouch!!!!!";
            count = count - 3;
            // vuelve al centro del tablero
            jugador.transform.position = Vector3.zero;
        }
   }
   void SetCountText(){
      
      countText.text = "Count: " + count.ToString();
      if (count >=100){
         winText.text = "YOU WIN!!!";
      }
      if (count > 90 && count < 100){
         winText.text = "YOU LOSE!!!";
      }


   }
}
