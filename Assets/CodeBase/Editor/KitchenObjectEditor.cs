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
            base.OnInspectorGUI();
            
            var kitchenObjectStaticData = target as KitchenObjectStaticData;

            if (kitchenObjectStaticData.canBeSliced)
            {
                kitchenObjectStaticData.sliced = EditorGUILayout.ObjectField(
                        "Sliced",
                        kitchenObjectStaticData.sliced,
                        typeof(KitchenObjectStaticData),
                        false,
                        GUILayout.Height(EditorGUIUtility.singleLineHeight))
                    as KitchenObjectStaticData;

                kitchenObjectStaticData.slicingProgressMaxValue = EditorGUILayout.IntSlider(
                        kitchenObjectStaticData.slicingProgressMaxValue,
                        1, 
                        5, 
                        GUILayout.Height(EditorGUIUtility.singleLineHeight)
                    );
                
                EditorUtility.SetDirty(target);
            }

            if (kitchenObjectStaticData.canBeCooked)
            {
                kitchenObjectStaticData.cooked = EditorGUILayout.ObjectField(
                        "Cooked",
                        kitchenObjectStaticData.cooked,
                        typeof(KitchenObjectStaticData),
                        false,
                        GUILayout.Height(EditorGUIUtility.singleLineHeight))
                    as KitchenObjectStaticData;
                
                kitchenObjectStaticData.burned = EditorGUILayout.ObjectField(
                        "Burned",
                        kitchenObjectStaticData.burned,
                        typeof(KitchenObjectStaticData),
                        false,
                        GUILayout.Height(EditorGUIUtility.singleLineHeight))
                    as KitchenObjectStaticData;

                kitchenObjectStaticData.cookDuration = EditorGUILayout.IntSlider(
                        kitchenObjectStaticData.cookDuration,
                        1,
                        5,
                        GUILayout.Height(EditorGUIUtility.singleLineHeight)
                    );

                kitchenObjectStaticData.burnDuration = EditorGUILayout.IntSlider(
                        kitchenObjectStaticData.burnDuration,
                        1, 
                        5, 
                        GUILayout.Height(EditorGUIUtility.singleLineHeight)
                    );
                
                EditorUtility.SetDirty(target);
            }
        }
    }
}