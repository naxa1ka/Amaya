using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var array = serializedObject.FindProperty("_cardBundleData");

        var countList = new List<int>();

        if (array.arraySize > 0)
        {
            for (int i = 0; i < array.arraySize; i++)
            {
                EditorGUILayout.BeginVertical("box");

                var cardBundleData = array.GetArrayElementAtIndex(i);
                
                DrawCardSO(cardBundleData);
                
                EditorGUILayout.Space();
                
                if (cardBundleData.objectReferenceValue != null)
                {
                    var card = (CardBundleData)cardBundleData.objectReferenceValue;
                    var cardDataCount = card.CardData.Count;
                    
                    countList.Add(cardDataCount);

                    DrawPreviews(card);
                    DrawIDs(card);

                    EditorGUILayout.LabelField($"Длина карточки {cardDataCount}");
                }
                

                if (GUILayout.Button("Удалить элемент"))
                {
                    array.DeleteArrayElementAtIndex(i);
                    break;
                }
                
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
            }
        }
        else
        {
            EditorGUILayout.LabelField("Нет элементов в списке!");
        }

        if (GUILayout.Button("Добавить элемент"))
        {
            array.InsertArrayElementAtIndex(array.arraySize);
        }

        if (countList.IsHomogeneously() == false)
        {
            EditorGUILayout.HelpBox("Длина строк отличается", MessageType.Warning);
        }


        serializedObject.ApplyModifiedProperties();
    }

    private static void DrawPreviews(CardBundleData card)
    {
        EditorGUILayout.BeginHorizontal();
        foreach (var cardData in card.CardData)
        {
            EditorGUILayout.ObjectField("", cardData.Sprite, typeof(Sprite), false, new GUILayoutOption[]
            {
                GUILayout.MinWidth(16),
                GUILayout.MinHeight(16),
            });
        }
        EditorGUILayout.EndHorizontal();
    }

    private static void DrawIDs(CardBundleData card)
    {
        StringBuilder stringBuilder = new StringBuilder("Идентификаторы: ");
        foreach (var cardData in card.CardData)
        {
            stringBuilder.Append(cardData.Identifier).Append(" ");
        }

        EditorGUILayout.LabelField(stringBuilder.ToString());
    }

    private static void DrawCardSO(SerializedProperty cardBundleData)
    {
        cardBundleData.objectReferenceValue = (CardBundleData)EditorGUILayout.ObjectField(
            $"Карточка",
            cardBundleData.objectReferenceValue, typeof(CardBundleData), false);
    }
}