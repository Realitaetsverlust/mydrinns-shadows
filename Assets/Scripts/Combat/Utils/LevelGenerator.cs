//Generates a tile based playing field
//Needs a generate.txt in the root folder of the project to work.
//Must contain numeric values representing the height, separated by "|" in order to work properly
//No error reporting or handling implemented
//Use at your own risk

using System;
using System.IO;
using Combat.Core;
using Combat.Core.TileTypes;
using Elements.TileTypes;
using UnityEngine;

namespace Combat.Utils {
	public class LevelGenerator : MonoBehaviour {

		private void Awake() {
			string[] fileContent;
			float positionX = 0;
			float positionZ = 0;
			int gridCounterHorizontal = 0;
			int gridCounterVertical = 0;

			if(GameObject.Find("terrainParent") != null) {
				Console.WriteLine("terrainParent already exists in scene - aborting.");
				return;
			}
		
			GameObject terrainParent = new GameObject("terrainParent");
			terrainParent.AddComponent<GridController>();
		
			try {
				fileContent = File.ReadAllLines("Assets/generate.txt");
			} catch(FileNotFoundException e) {
				Console.WriteLine(e);
				throw;
			}
		
			terrainParent.transform.position = new Vector3(0, 0, 0);
		
			foreach(string line in fileContent) {
				string[] map = line.Split('|');
				gridCounterVertical += 1;
				
				foreach(string tileInfo in map) {
					string[] tileInfoSplit = tileInfo.Split(',');
					int height = int.Parse(tileInfoSplit[0]);
					string terrain = tileInfoSplit[1];
					
					gridCounterHorizontal += 1;

					GameObject gridElement = GridElementBuilder.buildElement(height);
					gridElement.GetComponent<GridElement>().setTileType(this.getTileType(terrain));
					gridElement.GetComponent<GridElement>().setHeight(height);
					gridElement.transform.parent = terrainParent.transform;
					
					if(gridElement == null) {
						throw new Exception("terrainElement could not be loaded from Prefabs. Aborting.");
					}

					gridElement.transform.name = string.Concat(gridCounterVertical, "-", gridCounterHorizontal);
					gridElement.transform.position = new Vector3(positionX, 1f, positionZ);

					positionX += 1;
				}

				gridCounterHorizontal = 0;
			
				positionZ -= 1;
				positionX = 0;
			}
		}

		private TileType getTileType(string terrainType) {
			switch(terrainType) {
				case "oc":
					return new Ocean();
				case "wa":
					return new Water();
				case "ro":
					return new Rock();
				case "sd":
					return new Sand();
				case "mg":
					return new Magma();
				case "so":
					return new Snow();
				case "di":
					return new Dirt();
				case "wo":
					return new Wood();
				case "gr":
					return new Grass();
				default:
					//default
					return new Grass();
			}
		}
	}
}