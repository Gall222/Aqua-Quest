using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    bool isPlayerEnter = false;
    [SerializeField] AudioClip exitSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerAnimator = collision.GetComponent<Animator>();
        var playerRigidbody = collision.GetComponent<Rigidbody2D>();

        if (playerAnimator && !isPlayerEnter)
        {
            StartCoroutine(LvlExit());
            isPlayerEnter = true;
            playerAnimator.SetTrigger("Exit");
            //collision.transform.localScale = new Vector2(0, 1f);
            playerRigidbody.velocity = new Vector2(0f, 1f);
        }
    }

    IEnumerator LvlExit()
    {
        AudioSource.PlayClipAtPoint(exitSFX, Camera.main.transform.position);
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(2);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<ScenePersist>().DestroyOldObjects();
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1f;
    }


}
