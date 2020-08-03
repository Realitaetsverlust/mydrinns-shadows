namespace Combat.Core.TileTypes {
	public class Wood : TileType {
		public Wood() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize_Wood_diffuse");
		}
	}
}