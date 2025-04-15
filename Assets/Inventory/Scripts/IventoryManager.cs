using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
    public class IventoryManager : MonoBehaviour
    {
        public List<PanelScript> panelList = new List<PanelScript>();

        void Start()
        {
            panelList = GetComponents<PanelScript>().ToList();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
