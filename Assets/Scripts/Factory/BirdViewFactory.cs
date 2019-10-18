using System;
using FlappyBird.Collision;
using FlappyBird.Controller;
using SomeAnyBird.Controller;
using SomeAnyBird.Definition;
using SomeAnyBird.View;
using UnityEditor;
using UnityEngine;

namespace SomeAnyBird.Factory
{
    public class BirdViewFactory
    {
        public static BirdView CreateBirdView(BirdDefinition definition)
        {
            var prefab = Resources.Load(definition.PrefabName, typeof(GameObject)) as GameObject;
            if (prefab == null)
            {
                Debug.Log("Cant find prefab: " + definition.PrefabName);
                return null;
            }
            
            var newObject = MonoBehaviour.Instantiate(prefab, definition.position, prefab.transform.rotation);

            if (definition.isPlayer)
            {
                var gameController = GameObject.Find("GameController");
                var collisionListener = newObject.GetComponent<CollisionListener>();
                collisionListener?.onLayerCollisionDetect.AddListener(gameController.GetComponent<GameController>().End);
            }

            newObject.name = prefab.name;
            return newObject.GetComponent<BirdView>();
        }
    }
}