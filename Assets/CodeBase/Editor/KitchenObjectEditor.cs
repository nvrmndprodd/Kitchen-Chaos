using System;
using CodeBase.StaticData;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(KitchenObjectStaticData))]
    public class KitchenObjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var kitchenObjectStaticData = target as KitchenObjectStaticData;

            kitchenObjectStaticData.prefab = EditorGUILayout.ObjectField(
                    "Prefab",
                    kitchenObjectStaticData.prefab,
                    typeof(KitchenObject),
                    false,
                    GUILayout.Height(EditorGUIUtility.singleLineHeight)
                )
                as KitchenObject;

            kitchenObjectStaticData.icon = EditorGUILayout.ObjectField(
                    "Icon",
                    kitchenObjectStaticData.icon,
                    typeof(Sprite),
                    false,
                    GUILayout.Height(EditorGUIUtility.singleLineHeight)
                )
                as Sprite;

            kitchenObjectStaticData.objectName = EditorGUILayout.TextField(
                    "Object name",
                    kitchenObjectStaticData.objectName,
                    GUILayout.Height(EditorGUIUtility.singleLineHeight)
            );

            kitchenObjectStaticData.canBeSliced = EditorGUILayout.Toggle(
                    "Can be sliced",
                    kitchenObjectStaticData.canBeSliced
            );

            if (kitchenObjectStaticData.canBeSliced)
            {
                kitchenObjectStaticData.sliced = EditorGUILayout.ObjectField(
                        "Sliced",
                        kitchenObjectStaticData.sliced,
                        typeof(KitchenObjectStaticData),
                        false,
                        GUILayout.Height(EditorGUIUtility.singleLineHeight))
                    as KitchenObjectStaticData;
            }
        }
    }
}