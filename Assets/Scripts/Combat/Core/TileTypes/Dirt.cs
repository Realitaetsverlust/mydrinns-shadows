using Elements.TileTypes;

namespace Combat.Core.TileTypes {
	public class Dirt : TileType {
		public Dirt() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Metal");
		}
	}
}