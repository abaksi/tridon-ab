using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tridion.ContentManager.ContentManagement;
using Tridion.ContentManager.Extensibility;
using Tridion.ContentManager.Extensibility.Events;

namespace EventSystemTest
{
    // unique per Event System 
    [TcmExtension("TridionEventSystem")] 
    public class TestEvent : TcmExtension
    {
        public TestEvent()
        {
            Subscribe();
        }

        /// <summary>
        /// Here Goes Subscribe Method
        /// </summary>
        public void Subscribe()
        {
            // Subscribe Your Event
            EventSystem.Subscribe<Component, SaveEventArgs>(OnComponentSavePre, EventPhases.Initiated);
        }

        /// <summary>
        /// Custimized Logic on OnComponentSavePre Event
        /// </summary>
        /// <param name="comp"></param>
        /// <param name="args"></param>
        /// <param name="phase"></param>
        private static void OnComponentSavePre(Component comp, SaveEventArgs args, EventPhases phase)
        {
           //actual logic
            if (comp.Schema.Title == "EventSystem")
            {
                //schema based test
                comp.Title = "TestEventSystem " + comp.Title;
            }

        }
        
    }
}

