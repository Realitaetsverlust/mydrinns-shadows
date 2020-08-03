using Elements.TileTypes;

namespace Combat.Core.TileTypes {
	public class Snow : TileType {
		public Snow() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Snow");
		}
	}
}