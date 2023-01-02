#if UNITY_EDITOR
using Lockstep.Math;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LVector2Int))]
public class EditorLVector2Int : UnityEditor.PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
        var xProperty = property.FindPropertyRelative("x");
        var yProperty = property.FindPropertyRelative("y");
        float LabelWidth = EditorGUIUtility.labelWidth - EditorLVectorDrawTool.LableWidthOffset;
        float lableWid = EditorLVectorDrawTool.LableWid;

        var labelRect = new Rect(position.x, position.y, LabelWidth, position.height);
        EditorGUI.LabelField(labelRect, label);
        float filedWid = (position.width - LabelWidth) / 2 - lableWid;
        float initX = position.x + LabelWidth;
        float offset = 0;
        EditorLVectorDrawTool.DrawFieldInt(position, initX, ref offset, lableWid, filedWid, xProperty, new GUIContent("x:"));
        EditorLVectorDrawTool.DrawFieldInt(position, initX, ref offset, lableWid, filedWid, yProperty, new GUIContent("y:"));
    }
}
#endif