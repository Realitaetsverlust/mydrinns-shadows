using Elements.TileTypes;

namespace Combat.Core.TileTypes {
	public class Magma : TileType {
		public Magma() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize_Lava_diffuse");
			this.causedDamagePerTurn = 10;
		}
	}
}