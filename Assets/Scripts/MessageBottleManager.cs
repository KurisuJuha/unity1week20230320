using UnityEngine;
using JuhaKurisu.PopoTools.Utility;
using AnnulusGames.LucidTools.Inspector;

public class MessageBottleManager : Singleton<MessageBottleManager>
{
    [ShowInInspector, LabelText("Current MessageBottle Stage")] public int currentMessageBottleStage { get; private set; }
    [SerializeField, Required] private DropItem messageBottlePrefab;
    [SerializeField, ReadOnly] private DropItem currentStageMessageBottle;

    private void Start()
    {
        CreateMessageBottle();
    }

    [Button]
    public void AdvanceNextStage()
    {
        currentMessageBottleStage++;
        if (currentMessageBottleStage >= Settings.messageBottleList.Count) currentMessageBottleStage = Settings.messageBottleList.Count - 1;
        CreateMessageBottle();
    }

    private void CreateMessageBottle()
    {
        if (currentStageMessageBottle?.gameObject) Destroy(currentStageMessageBottle.gameObject);
        currentStageMessageBottle = Instantiate(messageBottlePrefab, Settings.messageBottleList[currentMessageBottleStage].position, Quaternion.identity);
        currentStageMessageBottle.gameObject.name = $"MessageBottle ({Settings.messageBottleList[currentMessageBottleStage].name})";
    }
}
