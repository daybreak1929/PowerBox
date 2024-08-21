using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class ClanCreationPower : Feature {
    internal override bool Init() {
      GodPower createClan = new GodPower() {
        id = "create_clan",
        name = "create_clan",
        click_special_action = ClanCreationAction
      };
      AssetManager.powers.add(createClan);
      return true;
    }
    private static bool ClanCreationAction(WorldTile pTile, string pPowerId) {
      MapBox.instance.getObjectsInChunks(pTile, 3, MapObjectType.Actor);
      Actor newClanLeader = MapBox.instance.temp_map_objects.FirstOrDefault(actor => actor.base_data.alive && actor.kingdom.isCiv())?.a;
      if (newClanLeader == null) {
        return false;
      }
      if (newClanLeader.hasClan()) {
        newClanLeader.getClan().removeUnit(newClanLeader.data);
      }
      World.world.clans.newClan(newClanLeader);
      newClanLeader.startShake();
      newClanLeader.startColorEffect();
      return true;
    }
  }
}
