using Elements.TileTypes;

namespace Combat.Core.TileTypes {
	public class Grass : TileType {
		public Grass() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize_Grass");
		}
	}
}