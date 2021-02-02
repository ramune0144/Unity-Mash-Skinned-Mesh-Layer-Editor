using UnityEngine;
using UnityEditor;
using System;
using UnityEditorInternal;
using System.Reflection;
namespace MIssingRemoverGUI {
    public class MissingRemover: MonoBehaviour {
        [MenuItem("Rabbit/Tool_rabbit")]
        static void Run() {
            EditorWindow.GetWindow<MissingRemoverGUI> (true, "Auto layer Tools");
        }
    }

    public class MissingRemoverGUI : EditorWindow
    {
        int odermoniter;
        int idmoni;
        int meshcount = 0;
        int meshcount2 = 0;
        int odermoniter2;
        int idmoni2;
        string name1 = "";
        string name2 = "";
        string name3 = "";
        GameObject avatar = null;
        //GameObject patis = null;
        Boolean layer = false;
        Boolean layer2 = false;
        string ptlay;
        int layerOder = 0;
        string layer_name = "";
        int layer_count = 0;
        ////////////for mesh
        int layerOder2 = 0;
        string layer_name2 = "";
        int layer_count2 = 0;
        Boolean layer3 = false;
    
        int layerOder3 = 0;
        string layer_name3 = "";
        int layer_count3 = 0;
        int meshcount3 = 0;
        int odermoniter3;
        int idmoni3;
        void OnGUI()
        {


            avatar = EditorGUILayout.ObjectField("GameObj", avatar, typeof(GameObject), true) as GameObject;

            GUILayout.Space(10);

           


            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();

            layer = GUILayout.Toggle(layer, "Layer_skin");

            EditorGUILayout.EndHorizontal();

            if (layer == true)
            {

                EditorGUILayout.BeginHorizontal();
                EditorGUI.BeginChangeCheck();
                layer_name = EditorGUILayout.TextField("layer_name", layer_name);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                layerOder = EditorGUILayout.IntField("layer_Order", layerOder);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                layer_count = EditorGUILayout.IntField("layer_No.", layer_count);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                if (avatar != null)
                {
                    if (GUILayout.Button("Set layer all auto"))
                    {
                        meshcount = 0;
                        layerskin(avatar);
                        /*layer_name = "";
                        layerOder = 0;
                        layer_count = 0;*/
                    }
                }

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(" oder: " + odermoniter + " Ids: " + idmoni + "  name : " + name1 + "  number of edited obj :" + meshcount);

                EditorGUILayout.EndHorizontal();    


                GUILayout.Space(15);
            }




            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();

            layer2 = GUILayout.Toggle(layer2, "Layer_mesh");

            EditorGUILayout.EndHorizontal();
            if (layer2 == true)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUI.BeginChangeCheck();
                layer_name2 = EditorGUILayout.TextField("layer_name", layer_name2);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                layerOder2 = EditorGUILayout.IntField("layer_Order", layerOder2);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                layer_count2 = EditorGUILayout.IntField("layer_No.", layer_count2);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                if (avatar != null)
                {
                    if (GUILayout.Button("Set layer all auto"))
                    {
                        meshcount2 = 0;
                        layermesh(avatar);

                        /*layer_name2 = "";
                        layerOder2 = 0;
                        layer_count2 = 0;*/
                    }
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(" oder: " + odermoniter2 + " Ids: " + idmoni2 + "  name : " + name2 + "  number of edited obj :" + meshcount2);

                EditorGUILayout.EndHorizontal();


                GUILayout.Space(15);
            }

            ////////////////////////////////////////////////
            ///EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();

            layer3 = GUILayout.Toggle(layer3, "Layer_particles");

            EditorGUILayout.EndHorizontal();

            if (layer3)
            {
              
                EditorGUILayout.BeginHorizontal();
                EditorGUI.BeginChangeCheck();
                layer_name3 = EditorGUILayout.TextField("layer_name", layer_name3);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                layerOder3 = EditorGUILayout.IntField("layer_Order", layerOder3);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                layer_count3 = EditorGUILayout.IntField("layer_No.", layer_count3);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                if (avatar != null)
                {
                    if (GUILayout.Button("Set layer all auto"))
                    {
                        meshcount3 = 0;
                        layerpaticle(avatar);

                    }
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(" oder: " + odermoniter3 + " Ids: " + idmoni3 + "  name : " + name3 + "  number of edited obj :" + meshcount3);
                EditorGUILayout.EndHorizontal();
            }
        }
        //////////////////////////////////////////////////////////////////////pati zone
        


        //////////////////////////////////////////////////////////////////////////////////////
        //skin_render Zone pls remember me

       /////////////////////////////////////////////////////////////////////////////////////////

        void layerskin(GameObject gameObject) {
            int[] layerID1 = GetSortingLayerUniqueIDs();
            SkinnedMeshRenderer[] skins = gameObject.GetComponents<SkinnedMeshRenderer>();
           
           // Debug.Log("Custom" + skins.Length);
            // SkinnedMeshRenderer ski = avatar.GetComponent<SkinnedMeshRenderer>();
            int count1 = 0;
           

            
                for (int i = 0; i < skins.Length; i++)
                {

                    SkinnedMeshRenderer skin = skins[i - count1];

                    skin.sortingOrder = layerOder > 32767 ? 32767 : layerOder;
                    odermoniter = skin.sortingOrder;

               // if (layer_count != 0)
                    skin.sortingLayerID = layerID1[layer_count];
                if (layer_name != "") 
                    skin.sortingLayerName = layer_name;

                name1 = skin.sortingLayerName;
                  

                    idmoni = skin.sortingLayerID;
                    count1++;
                meshcount++;


            }
            
           
            if (gameObject.transform.childCount > 0)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    layerskin(gameObject.transform.GetChild(i).gameObject);
                }
            }
           
        }

        void layermesh(GameObject gameObject)
        {
            int[] layerID2 = GetSortingLayerUniqueIDs();
            
            MeshRenderer[] meshs = gameObject.GetComponents<MeshRenderer>();
            // Debug.Log("Custom" + skins.Length);
            // SkinnedMeshRenderer ski = avatar.GetComponent<SkinnedMeshRenderer>();
           
            int count2 = 0;
            


            for (int i = 0; i < meshs.Length; i++)
                {


                    MeshRenderer mesh = meshs[i - count2];
          
                    mesh.sortingOrder = layerOder2 > 32767 ? 32767 : layerOder2;
                    odermoniter2 = mesh.sortingOrder;
               // if (layer_count2 != 0)
                    mesh.sortingLayerID = layerID2[layer_count2];
                idmoni2 = mesh.sortingLayerID;
                if (layer_name2 != "")
                    mesh.sortingLayerName = layer_name2;

                name2 = mesh.sortingLayerName;
               
                    count2++;
                meshcount2++;


                }
            
            if (gameObject.transform.childCount > 0)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    layermesh(gameObject.transform.GetChild(i).gameObject);
                }
                
            }
            
        }
        ///////////////////
        void layerpaticle(GameObject gameObject)
        {
            int[] layerID3 = GetSortingLayerUniqueIDs();

            ParticleSystemRenderer[] patis = gameObject.GetComponents<ParticleSystemRenderer>();
            // Debug.Log("Custom" + skins.Length);
            // SkinnedMeshRenderer ski = avatar.GetComponent<SkinnedMeshRenderer>();

            int count3 = 0;



            for (int i = 0; i < patis.Length; i++)
            {


                ParticleSystemRenderer  mesh = patis [i - count3];
               
                mesh.sortingOrder = layerOder3 > 32767 ? 32767 : layerOder3;
                odermoniter3 = mesh.sortingOrder;
              
                    mesh.sortingLayerID = layerID3[layer_count3];
                idmoni3 = mesh.sortingLayerID;
                if (layer_name3 != "")
                    mesh.sortingLayerName = layer_name3;

                name3 = mesh.sortingLayerName;

                count3++;
                meshcount3++;


            }

            if (gameObject.transform.childCount > 0)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    layerpaticle(gameObject.transform.GetChild(i).gameObject);
                }

            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////// 

       


        ///////////////////////////
        public int[] GetSortingLayerUniqueIDs()
        {
            Type internalEditorUtilityType = typeof(InternalEditorUtility);
            PropertyInfo sortingLayerUniqueIDsProperty = internalEditorUtilityType.GetProperty("sortingLayerUniqueIDs", BindingFlags.Static | BindingFlags.NonPublic);
            return (int[])sortingLayerUniqueIDsProperty.GetValue(null, new object[0]);
        }

    }
  }
    

    
