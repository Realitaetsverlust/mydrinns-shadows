using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.Core {
	public class GridController : MonoBehaviour {
		private static GameObject _grid;
		private static Dictionary<String, GameObject> _gridElements;
		private static GameObject _activeTile;
		private static GameObject _previousTile;
		private static GameObject _godObject;

		public static void loadGridSystem() {
			GridController._godObject = GameObject.Find("GodObject");
			GridController._grid = GameObject.Find("terrainParent");
			GridController._gridElements = new Dictionary<string, GameObject>();
		
			for(int index = 0; index < GridController._grid.transform.childCount; index++) {
				Transform child = GridController._grid.transform.GetChild(index);
				GridController._gridElements.Add(child.name, child.gameObject);
			}
		}

		public static void markNewTileAsActive(string id) {
			GridController._previousTile = GridController._activeTile;
			GridController._activeTile = GridController.getElementById(id);
		
			if(GridController._previousTile != null) {
				GridController._previousTile.GetComponent<GridElement>().unmarkAsActiveTile();
			}

			GridController._activeTile.GetComponent<GridElement>().markAsActiveTile();
		}

		public static GameObject getActiveTile() {
			if(GridController._activeTile != null) {
				return GridController._activeTile;
			}

			return null;
		}

		public static GameObject getElementById(string id) {
			if(GridController._gridElements == null) {
				GridController.loadGridSystem();
			}
		
			if(GridController._gridElements.ContainsKey(id)) {
				return GridController._gridElements[id];
			}

			return null;
		}

		public static Dictionary<string, float> getMaximumBoundsOfPlayingField() {
			Dictionary<string, float> positionalDictionary = new Dictionary<string, float>();
			positionalDictionary.Add("maxX", 0);
			positionalDictionary.Add("maxZ", 0);
			positionalDictionary.Add("minX", 0);
			positionalDictionary.Add("minZ", 0);
		
			foreach(KeyValuePair<string,GameObject> gridElement in GridController._gridElements) {
				Vector3 gridElementPosition = gridElement.Value.transform.position;
				
				if(gridElementPosition.x > positionalDictionary["maxX"]) {
					positionalDictionary["maxX"] = gridElementPosition.x;
				}	
			
				if(gridElementPosition.z > positionalDictionary["maxZ"]) {
					positionalDictionary["maxZ"] = gridElementPosition.z;
				}
				
				if(gridElementPosition.x < positionalDictionary["minX"]) {
					positionalDictionary["minX"] = gridElementPosition.x;
				}	
			
				if(gridElementPosition.z < positionalDictionary["minZ"]) {
					positionalDictionary["minZ"] = gridElementPosition.z;
				}
			}

			return positionalDictionary;
		}
	}
}