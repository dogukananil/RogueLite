namespace Managers
{
   public class GameManager : Singleton<GameManager>
   {
      public PlayerController playerController;
      public MapController mapController;
   }
}
