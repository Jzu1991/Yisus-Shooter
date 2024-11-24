using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f; // Velocidad de movimiento del jugador
    private Rigidbody playerBody; // Referencia al Rigidbody del jugador
    private bool canJump = true; // Controla si el jugador puede saltar
    public float jumpForce = 2.5f; // Fuerza del salto
    private bool gameover = false;
    public Disparo shootingScript; // Referencia al script de disparo
    public CameraControl cameraController; // Referencia al script de la cámara
    public GameObject Pantalladerrota;
    void Start()
    {
        // Obtener el Rigidbody del jugador y bloquear el cursor
        playerBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Pantalladerrota.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
       
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        Vector3 movement = transform.TransformDirection(moveDirection) * speed * Time.deltaTime;

        playerBody.MovePosition(playerBody.position + movement);

        // Liberar el cursor al presionar Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerBody.velocity = new Vector3(playerBody.velocity.x, jumpForce, playerBody.velocity.z);
            canJump = false; 
        }

        if (gameover)
        {
            Pantalladerrota.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Suelo")
        {
            canJump = true;
        }

        
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0f; // Pausar el tiempo
            gameover = true;
            Cursor.lockState = CursorLockMode.Confined; // Liberar el cursor
            shootingScript.enabled = false; // Desactivar el disparo
            cameraController.enabled = false; // Desactivar el control de la cámara
        }

        
        if (collision.gameObject.tag == "Killzone")
        {
            Time.timeScale = 0f; // Pausar el tiempo
            gameover = true;
            Cursor.lockState = CursorLockMode.Confined; // Liberar el cursor
            shootingScript.enabled = false; // Desactivar el disparo
            cameraController.enabled = false; // Desactivar el control de la cámara
        }
    }


}