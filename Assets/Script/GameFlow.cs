using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [Tooltip("Popup component when win")]
    [SerializeField]
    private GameObject m_gameWinPanel;

    [Tooltip("Popup component when lose")]
    [SerializeField]
    private GameObject m_gameOverPanel;

    [Tooltip("Player game object")]
    [SerializeField]
    private GameObject m_player;

    [Tooltip("Zombie GameObject")]
    [SerializeField]
    private GameObject m_zombie;

    [Tooltip("List of Pausable Object")]
    [SerializeField]
    private List<GameObject> pausableObjects;

    private void OnValidate()
    {
        for (int i = pausableObjects.Count - 1; i >= 0; i--)
        {
            if (
                pausableObjects[i] == null
                || !pausableObjects[i].TryGetComponent<IPausable>(out var _)
            )
            {
                pausableObjects.RemoveAt(i);
                continue;
            }
        }
    }

    private void Start() => PauseGame();

    [ContextMenu("Pause Game")]
    public void PauseGame()
    {
        for (int i = 0; i < pausableObjects.Count; i++)
        {
            var pausable = pausableObjects[i].GetComponent<IPausable>();
            pausable.Pause();
        }
    }

    [ContextMenu("Resume Game")]
    public void ResumeGame()
    {
        for (int i = 0; i < pausableObjects.Count; i++)
        {
            var pausable = pausableObjects[i].GetComponent<IPausable>();
            pausable.Resume();
        }
    }

    public void GameFlow_GameOver()
    {
        m_gameOverPanel.SetActive(true);
        EndGame();
    }

    public void GameFlow_GameWin()
    {
        m_gameWinPanel.SetActive(true);
        EndGame();
    }

    public void AddToPausableList(GameObject pausable) => pausableObjects.Add(pausable);

    public void RemoveFromPausableList(GameObject pausable) => pausableObjects.Remove(pausable);

    private void EndGame()
    {
        var listChild = m_player.GetComponentsInChildren<Shooting>();
        var hpBarBinder = m_player.GetComponentsInChildren<HpBarBinder>();
        var rotate = m_player.GetComponent<RotateByMouse>();
        var movement = m_player.GetComponent<MoveByKey>();
        var health = m_player.GetComponent<Health>();
        rotate.enabled = false;
        movement.enabled = false;
        health.enabled = false;
      
        for (var i = 0; i < listChild.Length; i++)
        {
            listChild[i].gameObject.SetActive(false);
        }
        for (var i = 0; i < hpBarBinder.Length; i++)
        {
            hpBarBinder[i].gameObject.SetActive(false);
        }

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
