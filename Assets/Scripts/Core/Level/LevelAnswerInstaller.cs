using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelAnswerInstaller : MonoBehaviour
{
    [SerializeField] private LevelAnswer _levelAnswer;

    private readonly List<string> _pastAnswers = new List<string>();

    public void Dispose()
    {
        _pastAnswers.Clear();
    }
    
    public void Init(LevelData levelData)
    {
        var allAnswers = AllAnswers(levelData);
        var selectedAnswer = SelectAnswer(allAnswers);
        
        _pastAnswers.Add(selectedAnswer);
        
        _levelAnswer.Init(selectedAnswer);
    }

    private List<string> AllAnswers(LevelData levelData)
    {
        List<string> availableAnswers = new List<string>();
        
        foreach (var cardBundleData in levelData.CardBundleData)
        {
            foreach (var cardData in cardBundleData.CardData)
            {
                availableAnswers.Add(cardData.Identifier);
            }
        }

        return availableAnswers;
    }

    private string SelectAnswer(List<string> list)
    {
        var availableAnswers = list.FindAll(s =>
        {
            return _pastAnswers.All(pastAnswer => s != pastAnswer);
        });

        return availableAnswers.RandomItem();
    }
}