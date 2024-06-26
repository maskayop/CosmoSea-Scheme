using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsAmountText;
    [SerializeField] TextMeshProUGUI giftsCostAmountText;

    TaskController[] taskControllers;
    List<TaskController> nonActiveTasks = new List<TaskController>();

    int starsAmount = 0;
    int giftsCostAmount = 0;

    void Awake()
    {
        taskControllers = FindObjectsOfType<TaskController>();

        foreach (var task in taskControllers)
        {
            if(task.canvasGroup.alpha != 1)
                nonActiveTasks.Add(task);
        }
    }

    void Start()
    {
        CountStars();
        CountGiftsCost();
    }

    public void ShowNonActiveTasks()
    {
        foreach (var task in nonActiveTasks)
            task.gameObject.SetActive(true);
    }

    public void HideNonActiveTasks()
    {
        foreach (var task in nonActiveTasks)
            task.gameObject.SetActive(false);
    }

    void CountStars()
    {
        for (int i = 0; i < taskControllers.Length; i++)
        {
            if (taskControllers[i].canvasGroup.alpha == 1 && taskControllers[i].rewardStarCheckmark.activeSelf && !taskControllers[i].isGift)
                starsAmount++;
        }

        starsAmountText.text = starsAmount.ToString();
    }

    void CountGiftsCost()
    {
        for (int i = 0; i < taskControllers.Length; i++)
        {
            if (taskControllers[i].isGift)
            {
                int value;
                int.TryParse(taskControllers[i].giftCostAmountText.text, out value);

                giftsCostAmount += value;
            }
        }

        giftsCostAmountText.text = giftsCostAmount.ToString();
    }
}