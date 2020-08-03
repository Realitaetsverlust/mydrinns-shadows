using Elements.TileTypes;

namespace Combat.Core.TileTypes {
	public class Rock : TileType {
		public Rock() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Rock Diffuse");
		}
	}
}