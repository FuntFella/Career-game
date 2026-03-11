using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public NPCRequest[] npcs;

    void Start()
    {
        ChooseRandomNPC();
    }

    public void ChooseRandomNPC()
    {
        foreach (NPCRequest npc in npcs)
        {
            npc.SetActiveRequest(false);
        }

        int randomNPC = Random.Range(0, npcs.Length);
        npcs[randomNPC].SetActiveRequest(true);
    }
}