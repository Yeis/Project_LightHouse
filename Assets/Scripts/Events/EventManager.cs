using System;
using System.Collections.Generic;
using System.Threading;

namespace DreamTeam.Lighthouse.Core.Events
{
    public class EventManager : IEventManager
    {
        private readonly Queue<GameEvent> eventQueue;

        private GameEvent currentEvent;

        public EventManager()
        {
            eventQueue = new Queue<GameEvent>();
            currentEvent = null;
        }

        private bool RunEvent(GameEvent gameEvent)
        {
            if (!gameEvent.IsReady())
            {
                return false;
            }

            Thread.Sleep(gameEvent.DelayInMiliSeconds);
            gameEvent.Run();
            return true;
        }

        private void EnqueueEvent(GameEvent gameEvent)
        {
            eventQueue.Enqueue(gameEvent);
            gameEvent.Status = EventStatus.Queued;
        }

        private void TryRunningEvent(GameEvent gameEvent)
        {
            if (!RunEvent(gameEvent))
            {
                // It was not possible to run the event, just enqueue it
                EnqueueEvent(gameEvent);
            }
        }

        public void AddEvent(GameEvent gameEvent, int delayInMiliSeconds = 0)
        {
            // New delay value (if any) overwrites event delay time
            gameEvent.DelayInMiliSeconds = delayInMiliSeconds != 0 ? delayInMiliSeconds : gameEvent.DelayInMiliSeconds;

            // // This is the first event added
            // if (eventQueue.Count == 0 && currentEvent == null)
            // {
            //     currentEvent = gameEvent;

            //     // Try to run it! The queue must remain empty
            //     TryRunningEvent(gameEvent);
            // }

            // // If no event is currently running nor is any queued next...
            // if (eventQueue.Count == 0 && currentEvent.Status == EventStatus.Finished)
            // {
            //     // Try to run it! The queue must remain empty
            //     TryRunningEvent(gameEvent);
            // }

            // In any other case, just enqueue the event
            EnqueueEvent(gameEvent);
        }

        /// <summary>
        /// Should be called every few seconds
        /// </summary>
        public void ConstantRun()
        {
            //Some event is currently running
            if(currentEvent != null) {
                if (currentEvent.Status == EventStatus.Running) {

                    //Update current event if it has already ended
                    if (currentEvent.HasEnded())
                    {
                        Console.WriteLine($"{nameof(currentEvent)} {currentEvent.Id} has ended...");
                        currentEvent.Status = EventStatus.Finished;
                        currentEvent = null;
                    }
                    else
                    {
                        // Nothing to do
                        Console.WriteLine($"{nameof(currentEvent)} {currentEvent.Id} is still running...");
                        return;
                    }
                }
            } 
            else if(eventQueue.Count > 0) {
                var nextEvent = eventQueue.Peek();
                if (RunEvent(nextEvent))
                {
                    // Next event started running
                    nextEvent.Status = EventStatus.Running;
                    currentEvent = nextEvent;
                    eventQueue.Dequeue();
                }
            }
            else
            {
                // Nothing to do
                Console.WriteLine("No event has been added...");
                return;
            }
        }

        public GameEvent CurrentEvent()
            => currentEvent;

        public GameEvent NextEvent()
            => eventQueue.Peek();
    }
}