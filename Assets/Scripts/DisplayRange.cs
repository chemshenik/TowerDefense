using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(Tower))]
public class DisplayRange : Editor
{
    private void OnSceneGUI()
    {
        Tower displayRange = (Tower)target;
        if (displayRange.type == null)
            return;
        Handles.color = Color.black;
        Handles.DrawWireDisc(displayRange.shootPosition.position, Vector3.forward, displayRange.range);

        

        //Vector3 point = displayRange.transform.position + AngleA * displayRange.range;

        Handles.color = Color.white;
        if(displayRange.mainTarget != null)
        Handles.DrawLine(displayRange.shootPosition.position, displayRange.mainTarget.transform.position);
    }
    public override void OnInspectorGUI()
    {
        Tower tower = (Tower)target;
        tower.shootPosition = (Transform)EditorGUILayout.ObjectField("ShootPosition", tower.shootPosition, typeof(Transform), true);
        tower.type = (Towers)EditorGUILayout.ObjectField("Tower", tower.type, typeof(Towers), true);
        if (tower.type == null)
            return;
        EditorGUILayout.LabelField("Tower:", tower.type.name);
        tower.name = tower.type.name;
        EditorGUILayout.LabelField("Price:", tower.type.price.ToString());
        tower.price = tower.type.price;
        EditorGUILayout.LabelField("Range:", tower.type.range.ToString());
        tower.range = tower.type.range;
        EditorGUILayout.LabelField("Damage:", tower.type.damage.ToString());
        tower.damage = tower.type.damage;
        EditorGUILayout.LabelField("Attack speed:", tower.type.speedAttack.ToString());
        tower.speed_attack = tower.type.speedAttack;
        tower.bullet = tower.type.bulletSprite;
        if(tower.currentlvl == 1)
        tower.GetComponent<SpriteRenderer>().sprite = tower.type.level1;
    }
}