using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStatus : MobStatus
{
    [SerializeField] private AudioSource DeathSound;

    protected override void OnDie() {
        base.OnDie();
        if (DeathSound != null)
        {
            DeathSound.Play();
        }

        StartCoroutine(GoToGameOverCoroutine());
    }

    private IEnumerator GoToGameOverCoroutine() {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("GameOverScene");
    }
}
