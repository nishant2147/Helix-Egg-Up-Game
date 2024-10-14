using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject GameOverPage,GameWinner;
    private Camera mainCamera;
    private Rigidbody rb;
    float Ballbounce = 400f;
    bool isGameOver = false;
    bool isGameComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver && isGameComplete) return;

        Vector3 playerView = mainCamera.WorldToViewportPoint(transform.position);

        if (playerView.x < 0 || playerView.x > 1 ||
            playerView.y < 0 || playerView.y > 1)
        {
            rb.isKinematic = true;
            GameOverPage.SetActive(true);
            isGameOver = true;
            //print("Game Over! Player is out of bounds.");
        }
       
    }
    private void OnCollisionEnter(Collision collider)
    {
        rb.velocity = new Vector3(rb.velocity.x, Ballbounce * Time.deltaTime, rb.velocity.z);
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FinishLine"))
        {
            rb.isKinematic = true;
            GameWinner.SetActive(true);
            isGameComplete = true;
           
        }
            
    }
}
