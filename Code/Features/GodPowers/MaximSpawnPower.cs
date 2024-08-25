using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class MaximSpawnPower : AssetFeature<GodPower> {
    internal override FeatureRequirementList RequiredFeatures => typeof(Actors.Maxim);
    protected override GodPower InitObject() {
      return new GodPower {
        id = "spawnMaximCreature",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        name = "spawnMaximCreature",
        spawnSound = "spawnHuman",
        actor_asset_id = GetFeature<Actors.Maxim>().Object.id,
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
