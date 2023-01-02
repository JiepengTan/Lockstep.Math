//https://github.com/JiepengTan/LockstepMath

#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Lockstep.Math;
using UnityEngine;
using UnityEditor;

public static class EditorLVectorDrawTool {
    public const float LableWidthOffset = 45;
    public const float LableWid = 20;

    public static void DrawField(Rect position, float initX, ref float offset, float lableWid, float filedWid,
        SerializedProperty property, GUIContent label){
        var lableRect = new Rect(initX + offset, position.y, 70, position.height);
        EditorGUI.LabelField(lableRect, label.text);
        var valRect = new Rect(initX + offset + lableWid, position.y, filedWid, position.height);
        var fVal = EditorGUI.DoubleField(valRect, property.longValue * 1.0f / LFloat.Precision);
        property.longValue = (long) (fVal * LFloat.Precision);
        offset += filedWid + lableWid;
    }
    public static void DrawFieldInt(Rect position, float initX, ref float offset, float lableWid, float filedWid,
        SerializedProperty property, GUIContent label){
        var lableRect = new Rect(initX + offset, position.y, 70, position.height);
        EditorGUI.LabelField(lableRect, label.text);
        var valRect = new Rect(initX + offset + lableWid, position.y, filedWid, position.height);
        var fVal = EditorGUI.IntField(valRect, property.intValue);
        property.intValue = (int) (fVal );
        offset += filedWid + lableWid;
    }
}
#endif