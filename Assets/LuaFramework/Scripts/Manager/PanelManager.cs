using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

namespace LuaFramework {
    public class PanelManager : Manager {
        private Transform parent;

        Transform Parent {
            get {
                if (parent == null) {
                    GameObject go = GameObject.FindWithTag("GuiCamera");
                    Debug.Log("GuiCamera" + go);
                    if (go != null) parent = go.transform;
                }
                return parent;
            }
        }

        /// <summary>
        /// ������壬������Դ������
        /// </summary>
        /// <param name="type"></param>
        public void CreatePanel(string name, LuaFunction func = null) {
            StartCoroutine(StartCreatePanel(name, func));
        }

        /// <summary>
        /// �������
        /// </summary>
        IEnumerator StartCreatePanel(string name, LuaFunction func = null) {
            AssetBundle bundle = ResManager.LoadBundle(name);

            name += "Panel";
            GameObject prefab = null;
#if UNITY_5
            prefab = bundle.LoadAsset(name, typeof(GameObject)) as GameObject;
#else
            prefab = bundle.LoadAsset(name, typeof(GameObject)) as GameObject;
#endif
            yield return new WaitForEndOfFrame();

            if (Parent.Find(name) != null || prefab == null) {
                yield break;
            }
            GameObject go = Instantiate(prefab) as GameObject;
            go.name = name;
            go.layer = LayerMask.NameToLayer("Default");
            go.transform.parent = Parent;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;

            yield return new WaitForEndOfFrame();
            go.AddComponent<LuaBehaviour>().OnInit(bundle);

            if (func != null) func.Call(go);
            Debug.Log("StartCreatePanel------>>>>" + name);
        }

        /// <summary>
        /// �ر����
        /// </summary>
        /// <param name="name"></param>
        public void ClosePanel(string name) {
            var panelName = name + "Panel";
            var panelObj = Parent.transform.Find(panelName);
            Debug.Log(Parent.name);
            Debug.Log(panelName);
            if (panelObj == null) return;
            Debug.Log("Destroy");
            Destroy(panelObj.gameObject);
        }
    }
}