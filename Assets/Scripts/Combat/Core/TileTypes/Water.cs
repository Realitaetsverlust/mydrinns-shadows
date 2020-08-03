namespace Combat.Core.TileTypes {
	public class Water : TileType {
		public Water() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Water Diffuse");
		}
	}
}