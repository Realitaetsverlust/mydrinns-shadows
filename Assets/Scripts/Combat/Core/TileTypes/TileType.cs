using System;
using UnityEngine;

namespace Combat.Core.TileTypes {
    public class TileType {
        public bool passable;
        public string terrainType;
        public int causedDamagePerTurn;
        public int causedHealingPerTurn;
        protected Material tileMaterial;
        protected const string FIX_ME_MATERIAL = "Material/FixMe";

        protected const string TERRAIN_FILEPATH = "Material/Stylize Terrain Texture/Materials/";

        protected TileType() {
            this.causedDamagePerTurn = 0;
            this.causedHealingPerTurn = 0;
            this.passable = true;
        }

        protected Material getTerrainMaterial(string materialName, string customTerrainFilepath = null) {
            if(customTerrainFilepath != null) {
                return Resources.Load(String.Concat(customTerrainFilepath, materialName)) as Material;
            }

            Material sourceMaterial = Resources.Load(String.Concat(TileType.TERRAIN_FILEPATH, materialName)) as Material;
            
            if(sourceMaterial == null) {
                return Resources.Load(TileType.FIX_ME_MATERIAL) as Material;
            }

            sourceMaterial.mainTexture.wrapMode = TextureWrapMode.Repeat;

            return sourceMaterial;
        }

        public Material getTerrainMaterial() {
            return this.tileMaterial;
        }
    }
}