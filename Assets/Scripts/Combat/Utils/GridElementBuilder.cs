using System.Collections.Generic;
using Combat.Core;
using Elements;
using UnityEngine;

namespace Combat.Utils {
    public static class GridElementBuilder
    {
        // Start is called before the first frame update
        public static GameObject buildElement(int height) {
            GameObject terrainElement = new GameObject();
            GridElementBuilder.generateCube(height).transform.parent = terrainElement.transform;
            GridElementBuilder.generateIndicator(height).transform.parent = terrainElement.transform;
            
            terrainElement.AddComponent<GridElement>();

            return terrainElement;
        }

        private static GameObject generateCube(int height) {
            GameObject cubeParent = new GameObject();
            cubeParent.gameObject.name = "cube";
            GameObject bottom = GridElementBuilder.generateWallElement();
            bottom.gameObject.name = "bottom";
            bottom.transform.parent = cubeParent.transform;
            bottom.transform.position = new Vector3(0, 0, 0);
            
            GameObject northWallContainer = new GameObject();
            northWallContainer.gameObject.name = "north";
            northWallContainer.transform.parent = cubeParent.transform;
            GameObject eastWallContainer = new GameObject();
            eastWallContainer.gameObject.name = "east";
            eastWallContainer.transform.parent = cubeParent.transform;
            GameObject southWallContainer = new GameObject();
            southWallContainer.gameObject.name = "south";
            southWallContainer.transform.parent = cubeParent.transform;
            GameObject westWallContainer = new GameObject();
            westWallContainer.gameObject.name = "west";
            westWallContainer.transform.parent = cubeParent.transform;

            for(int i = 0; i < height; i++) {
                GameObject[] walls = GridElementBuilder.generateCubeWalls(i);
                walls[0].transform.parent = northWallContainer.transform;
                walls[1].transform.parent = eastWallContainer.transform;
                walls[2].transform.parent = southWallContainer.transform;
                walls[3].transform.parent = westWallContainer.transform;
            }

            GameObject top = GridElementBuilder.generateWallElement();
            top.gameObject.name = "top";
            top.transform.parent = cubeParent.transform;
            top.transform.position = new Vector3(0, height, 0);

            return cubeParent;
        }

        private static GameObject[] generateCubeWalls(int iteration) {
            float height = iteration + 0.5f;
            GameObject[] walls = new GameObject[4];
        
            GameObject northWall = GridElementBuilder.generateWallElement();
            northWall.gameObject.name = "northWall" + iteration;
            northWall.transform.position = new Vector3(0, height, -0.5f);
            northWall.transform.eulerAngles = new Vector3(90f, 0, 0);
            walls[0] = northWall;
        
            GameObject eastWall = GridElementBuilder.generateWallElement();
            eastWall.gameObject.name = "eastWall" + iteration;
            eastWall.transform.position = new Vector3(0.5f, height, 0);
            eastWall.transform.eulerAngles = new Vector3(90f, 0, 90f);
            walls[1] = eastWall;
        
            GameObject southWall = GridElementBuilder.generateWallElement();
            southWall.gameObject.name = "southWall" + iteration;
            southWall.transform.position = new Vector3(0, height, 0.5f);
            southWall.transform.eulerAngles = new Vector3(90f, 0, 0);
            walls[2] = southWall;
        
            GameObject westWall = GridElementBuilder.generateWallElement();
            westWall.gameObject.name = "westWall" + iteration;
            westWall.transform.position = new Vector3(-0.5f, height, 0);
            westWall.transform.eulerAngles = new Vector3(90f, 0, 90f);
            walls[3] = westWall;

            return walls;
        }

        private static GameObject generateWallElement() {
            GameObject element = GameObject.CreatePrimitive(PrimitiveType.Cube);
            element.transform.localScale = new Vector3(1, 0.0001f, 1);
            return element;
        }

        private static GameObject generateIndicator(int height) {
            GameObject indicator = GridElementBuilder.generateWallElement();
            indicator.transform.position = new Vector3(0, height + .01f, 0);
            indicator.gameObject.name = "indicator";
            return indicator;
        }
    }
}
