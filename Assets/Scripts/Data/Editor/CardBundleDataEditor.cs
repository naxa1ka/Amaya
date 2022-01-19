using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardBundleData))]
public class CardBundleDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        var array = serializedObject.FindProperty("_cardData");

        if (array.arraySize > 0)
        {
            for (int i = 0; i < array.arraySize; i++)
            {
                EditorGUILayout.BeginVertical("box");

                var elementAtIndex = array.GetArrayElementAtIndex(i);

                DrawSprite(elementAtIndex);
                DrawId(elementAtIndex);

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
        
        serializedObject.ApplyModifiedProperties();
    }

    private static void DrawSprite(SerializedProperty elementAtIndex)
    {
        var sprite = elementAtIndex.FindPropertyRelative("_sprite");
        sprite.objectReferenceValue = (Sprite)EditorGUILayout.ObjectField("Картинка",
            sprite.objectReferenceValue, typeof(Sprite), false);
    }

    private static void DrawId(SerializedProperty elementAtIndex)
    {
        var identifier = elementAtIndex.FindPropertyRelative("_identifier");
        identifier.stringValue = EditorGUILayout.TextField("Идентификатор", identifier.stringValue);
    }
}