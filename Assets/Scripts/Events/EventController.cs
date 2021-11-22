using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamTeam.Lighthouse.Core.Events
{
    public class EventController : MonoBehaviour
    {
        public float secondsBetweenReview;
        public List<DialogScriptableObject> introDialogs;
        private EventManager manager;

        private float t;
        // Start is called before the first frame update
        void Start()
        {
            manager = new EventManager();
            for (int i = 0; i < introDialogs.Count; i++)
            {
                manager.AddEvent(new DialogueEvent(introDialogs[i]));

            }
            t = 0.0f;
        }

        void  Update()
        {
            t += Time.deltaTime;
            if(t >= secondsBetweenReview) {
                manager.ConstantRun();
                t = 0.0f;
            }

        }

        public void AddEvent(GameEvent gameEvent) {
            manager.AddEvent(gameEvent);
        }

    }
}
