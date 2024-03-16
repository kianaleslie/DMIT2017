using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public InventoryManager playerInventory;
    public ChestController[] chests;
    public static string path = $"Inventory";

    //save method to save the current items in the chests
    public void SaveGame()
    {
        if (!Directory.Exists($"{path}/InventoryData"))
        {
            Directory.CreateDirectory($"{path}/InventoryData");
        }
        GameState gameState = new GameState();

        gameState.PlayerInventory = playerInventory.GetInventory();
        gameState.ChestContents = new ChestContents[chests.Length];

        for (int i = 0; i < chests.Length; i++)
        {
            gameState.ChestContents[i] = new ChestContents();
            gameState.ChestContents[i].ChestType = chests[i].chestType;
            gameState.ChestContents[i].Item1 = chests[i].displayText.text;
            gameState.ChestContents[i].Item2 = chests[i].displayText2.text;
            gameState.ChestContents[i].Item3 = chests[i].displayText3.text;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(GameState));
        using (FileStream stream = new FileStream($"{path}/InventoryData", FileMode.Create))
        {
            serializer.Serialize(stream, gameState);
        }
    }

    //load data method in order to load the current chest data on reload
    public void LoadGame()
    {
        if (File.Exists($"{path}/InventoryData"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameState));
            using (FileStream stream = new FileStream($"{path}/InventoryData", FileMode.Open))
            {
                GameState gameState = serializer.Deserialize(stream) as GameState;

                playerInventory.SetInventory(gameState.PlayerInventory);

                for (int i = 0; i < chests.Length; i++)
                {
                    chests[i].displayText.text = gameState.ChestContents[i].Item1;
                    chests[i].displayText2.text = gameState.ChestContents[i].Item2;
                    chests[i].displayText3.text = gameState.ChestContents[i].Item3;
                }
            }
        }
    }
}