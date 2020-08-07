using System.Collections.Generic;
using Combat.Core.TileTypes;
using Elements.TileTypes;
using UnityEngine;

namespace Combat.Core {
    public class GridElement : MonoBehaviour {
        private MeshRenderer _renderer;
        private int _height;

        private GameObject _cube;
       
        private GameObject _top;
        private GameObject _bottom;
        private GameObject _north;
        private List<GameObject> _northPanels = new List<GameObject>();
        private GameObject _east;
        private List<GameObject> _eastPanels = new List<GameObject>();
        private GameObject _south;
        private List<GameObject> _southPanels = new List<GameObject>();
        private GameObject _west;
        private List<GameObject> _westPanels = new List<GameObject>();

        private GameObject _mark;
        private GameObject _northMark;
        private GameObject _eastMark;
        private GameObject _southMark;
        private GameObject _westMark;

        private GameObject _indicator;

        private GameObject _playerOnTile;

        public TileType tileType;
        
        public void Awake() {
            this._renderer = this.GetComponent<MeshRenderer>();
            
            this._cube = this.transform.Find("cube").gameObject;
            this._top = this.transform.Find("cube/top").gameObject;
            this._bottom = this.transform.Find("cube/bottom").gameObject;
            this._north = this.transform.Find("cube/north").gameObject;
            
            for(int index = 0; index < this._north.transform.childCount; index++) {
                Transform child = this._north.transform.GetChild(index);
                this._northPanels.Add(child.gameObject);
            }
            
            this._east = this.transform.Find("cube/east").gameObject;
                        
            for(int index = 0; index < this._east.transform.childCount; index++) {
                Transform child = this._east.transform.GetChild(index);
                this._eastPanels.Add(child.gameObject);
            }

            this._south = this.transform.Find("cube/south").gameObject;
                        
            for(int index = 0; index < this._south.transform.childCount; index++) {
                Transform child = this._south.transform.GetChild(index);
                this._southPanels.Add(child.gameObject);
            }

            this._west = this.transform.Find("cube/west").gameObject;
                        
            for(int index = 0; index < this._west.transform.childCount; index++) {
                Transform child = this._west.transform.GetChild(index);
                this._westPanels.Add(child.gameObject);
            }
            
            this._mark = this.transform.Find("mark").gameObject;
            this._northMark = this.transform.Find("mark/northMark").gameObject;
            this._eastMark = this.transform.Find("mark/eastMark").gameObject;
            this._southMark = this.transform.Find("mark/southMark").gameObject;
            this._westMark = this.transform.Find("mark/westMark").gameObject;

            this._indicator = this.transform.Find("indicator").gameObject;

            this._playerOnTile = null;
        }

        /**
         * Marks the top element of a tile
         */
        public void markAsActiveTile() {
            this._mark.SetActive(true);
        }

        /**
         * Unmarks the top element of a tile
         */
        public void unmarkAsActiveTile() {
            this._mark.SetActive(false);
        }

        public void setCharacterToThisTile(GameObject oldTile, GameObject player) {
            if(oldTile != null) {
                oldTile.GetComponent<GridElement>().emptyCharacterSlot();
            }
            this._playerOnTile = player;
        }

        public void emptyCharacterSlot() {
            this._playerOnTile = null;
        }

        public GameObject getCharacterOnThisTile() {
            return this._playerOnTile;
        }

        public Vector3 getCenterPositionForCharacter() {
            Vector3 center = this._renderer.bounds.center;
            return new Vector3(center.x, this._height + 1.5f, center.z);
        }

        public void displayIndicator(string typing) {
            this.setIndicatorMaterial(typing);
            
            this._indicator.SetActive(true);
        }

        public void hideIndicator() {
            this._indicator.SetActive(false);
        }

        public void setTileType(TileType tileTyping) {
            this.tileType = tileTyping;
            this.updateTile();
        }

        public void setHeight(int height) {
            this._height = height;
        }

        public int getHeight() {
            return this._height;
        }

        public void updateTile() {
            this._top.GetComponent<Renderer>().material = this.tileType.getTerrainMaterial();
            this._bottom.GetComponent<Renderer>().material = this.tileType.getTerrainMaterial();

            foreach(GameObject panel in this._northPanels) {
                panel.GetComponent<Renderer>().material = this.tileType.getTerrainMaterial();
            }
            
            foreach(GameObject panel in this._southPanels) {
                panel.GetComponent<Renderer>().material = this.tileType.getTerrainMaterial();
            }
            
            foreach(GameObject panel in this._eastPanels) {
                panel.GetComponent<Renderer>().material = this.tileType.getTerrainMaterial();
            }
            
            foreach(GameObject panel in this._westPanels) {
                panel.GetComponent<Renderer>().material = this.tileType.getTerrainMaterial();
            }
        }

        private void setIndicatorMaterial(string typing) {
            switch(typing) {
                case "movement":
                    this._indicator.GetComponent<Renderer>().material = Resources.Load("Material/MovementRangeMaterial") as Material;
                    break;
                case "ability":
                    this._indicator.GetComponent<Renderer>().material = Resources.Load("Material/AbilityRangeMaterial") as Material;
                    break;
            }
        }
    }
}
