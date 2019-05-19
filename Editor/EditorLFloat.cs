#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Lockstep.Math;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(LFloat))]
public class EditorLFloat : UnityEditor.PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
        var xProperty = property.FindPropertyRelative("_val");
        float LabelWidth = EditorGUIUtility.labelWidth;
        var labelRect = new Rect(position.x, position.y, LabelWidth, position.height);
        var xRect = new Rect(position.x + LabelWidth, position.y, (position.width - LabelWidth) / 2 - 20,
            position.height);
        var val = xProperty.intValue * 1.0f / LFloat.Precision;
        EditorGUIUtility.labelWidth = 12.0f;
        EditorGUI.LabelField(labelRect, label);
        var fVal = EditorGUI.FloatField(xRect, val);
        xProperty.intValue = (int) (fVal * LFloat.Precision);
        EditorGUIUtility.labelWidth = LabelWidth;
    }
}
#endif