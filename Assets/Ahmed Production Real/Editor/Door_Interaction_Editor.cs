using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Door_Interaction)), CanEditMultipleObjects]
public class Door_Interaction_Editor : Editor
{
    private SerializedProperty doorMovementType;
    private SerializedProperty open;
    private SerializedProperty locked;
    private SerializedProperty maxDistance;
    private SerializedProperty rotateAngle;
    private SerializedProperty speed;
    private SerializedProperty rotateAxis;
    private SerializedProperty startingPosition;
    private SerializedProperty endingPosition;
    private SerializedProperty keyToPress;
    private SerializedProperty crosshairScript;

    public void OnEnable()
    {
        doorMovementType = serializedObject.FindProperty("doorMovementType");
        open = serializedObject.FindProperty("open");
        locked = serializedObject.FindProperty("locked");
        maxDistance = serializedObject.FindProperty("maxDistance");
        rotateAngle = serializedObject.FindProperty("rotateAngle");
        speed = serializedObject.FindProperty("speed");
        rotateAxis = serializedObject.FindProperty("rotateAxis");
        startingPosition = serializedObject.FindProperty("startingPosition");
        endingPosition = serializedObject.FindProperty("endingPosition");
        keyToPress = serializedObject.FindProperty("keyToPress");
        crosshairScript = serializedObject.FindProperty("crosshairScript");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var myScript = target as Door_Interaction;

        EditorGUILayout.PropertyField(doorMovementType);
        EditorGUILayout.PropertyField(open);
        EditorGUILayout.PropertyField(locked);

        EditorGUILayout.PropertyField(maxDistance);
        EditorGUILayout.PropertyField(speed);
        if (myScript.doorMovementType == Door_Interaction.doorType.RotatingDoor) {
            EditorGUILayout.PropertyField(rotateAngle);
            EditorGUILayout.PropertyField(rotateAxis);
        } else if (myScript.doorMovementType == Door_Interaction.doorType.SlidingDoor) {
            EditorGUILayout.PropertyField(startingPosition);
            EditorGUILayout.PropertyField(endingPosition);
        }

        EditorGUILayout.PropertyField(keyToPress);
        EditorGUILayout.PropertyField(crosshairScript);

        serializedObject.ApplyModifiedProperties();
        if (GUI.changed == true) {
            EditorUtility.SetDirty(target);
        }
    }
}
