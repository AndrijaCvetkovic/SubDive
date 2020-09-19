using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject {

    public List<Story> stories;
    public List<Mission> missions;
    public List<Chanlange> chanlanges;
    public List<PuzzlePartsChallange> puzzlePartsChallanges;
}

[System.Serializable]
public class Story
{
    public string name;
    public Sprite Bck;
    public Sprite Image;
    public List<GameObject> panelsPrefabs;
    public Mode mode = Mode.whileNotHitObsticle;
}

[System.Serializable]
public class Mission
{
    public string name;
    public GameObject prefabOfSavingObject;
    public int numberOfCreaturesNeedToBeSaved;
    public int numberOfSavedCreatures = 0;

    public Sprite Bck;
    public Sprite Image;
    public List<GameObject> panelsPrefabs;
    public bool missionCompleted = false;

    public Mode mode;
}

[System.Serializable]
public class Chanlange
{
    //da se skupljaju slova i da se zavrsi rec sutra
    public float metersToPass;
}

[System.Serializable]
public class PuzzlePartsChallange
{
    public string name;
    public List<GameObject> parts;
}

public enum Mode
{ 
    saveTheCreatures = 1,
    whileNotHitObsticle = 2,
    landWithParachute = 3
}


