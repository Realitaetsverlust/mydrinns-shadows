using Elements.TileTypes;

namespace Combat.Core.TileTypes {
	public class Sand : TileType {
		public Sand() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Sand");
		}
	}
}