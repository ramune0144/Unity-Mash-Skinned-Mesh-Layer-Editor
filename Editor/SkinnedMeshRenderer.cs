
using UnityEngine;
using UnityEditor;

using System;
using UnityEditorInternal;
using System.Reflection;
//editby :rabbit_candy

[CustomEditor(typeof(SkinnedMeshRenderer))]
public class SkinMashLayer_editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        bool OnMax_ramuneUWU = false;//on max_check
        bool auto_all = false;
        bool autod1 = false;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.richText = true;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("<b><color=#0068FF>SkinnedMesh_SortingLayers v1.2:</color></b>", style);
        SkinnedMeshRenderer ren = target as SkinnedMeshRenderer;//^-^
        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginChangeCheck();
        int[] layerID1 = GetSortingLayerUniqueIDs();
        //max
        auto_all = GUILayout.Toggle(auto_all, "All max");
        EditorGUILayout.LabelField("<b><color=#FF0000>you max No. of layer = </color></b>" + "<b><color=#6400FF>" + (layerID1.Length - 1) + " </color></b>", style);
        int index = Array.IndexOf(layerID1, ren.sortingLayerID);
        EditorGUILayout.EndHorizontal();
        
            if (auto_all)
            {
                //ren.sortingLayerName = "ramune_lay2";

                ren.sortingLayerID = layerID1[layerID1.Length - 1];
                ren.sortingOrder = 32767;
            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUI.BeginChangeCheck();

                autod1 = GUILayout.Toggle(auto_all, "All max Order-1");
                if (autod1)
                { //max-1

                    ren.sortingLayerID = layerID1[layerID1.Length - 1];
                    ren.sortingOrder = 32766;
                    EditorGUILayout.EndHorizontal();
                }


                else
                {
                    EditorGUILayout.EndHorizontal();
                    //begin get and change val of lay
                    EditorGUILayout.BeginHorizontal();
                    EditorGUI.BeginChangeCheck();
                    int layerNo = EditorGUILayout.IntField("you layer", index);
                    if (EditorGUI.EndChangeCheck()) { ren.sortingLayerID = layerID1[layerNo]; }
                    EditorGUILayout.EndHorizontal();
                    ///////////////////////////////////////////////////////////////////////////
                    EditorGUILayout.BeginHorizontal();
                    EditorGUI.BeginChangeCheck();

                    string layername = EditorGUILayout.TextField("Layer_name", ren.sortingLayerName);
                    if (layername != ren.sortingLayerName) 
                    
                    {

                        ren.sortingLayerName = layername;


                    }
                    EditorGUILayout.EndHorizontal();
                    //begin get and change val of layer id
                    EditorGUILayout.BeginHorizontal();
                    EditorGUI.BeginChangeCheck();
                    int layerID = EditorGUILayout.IntField("Layer_ID", ren.sortingLayerID);
                    if (EditorGUI.EndChangeCheck()) { ren.sortingLayerID = layerID; }
                    EditorGUILayout.EndHorizontal();
                    //begin and change val of layer oder
                    EditorGUILayout.BeginHorizontal();
                    EditorGUI.BeginChangeCheck();
                    int layerOder = EditorGUILayout.IntField("layer_Order", ren.sortingOrder);
                    OnMax_ramuneUWU = GUILayout.Toggle(OnMax_ramuneUWU, "to max order");
                    // EditorGUILayout.LabelField("<b><color=#EE4035FF>max(32767)</color></b>", style);
                    if (EditorGUI.EndChangeCheck())
                    {

                        ren.sortingOrder = OnMax_ramuneUWU || layerOder > 32767 ? 32767 : layerOder;
                        //OnMax = false;
                    }
                    EditorGUILayout.EndHorizontal();
                    //end
                }
            }///VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV
            

        
        
    }
    

    public int[] GetSortingLayerUniqueIDs()
    {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayerUniqueIDsProperty = internalEditorUtilityType.GetProperty("sortingLayerUniqueIDs", BindingFlags.Static | BindingFlags.NonPublic);
        return (int[])sortingLayerUniqueIDsProperty.GetValue(null, new object[0]);
    }


}




