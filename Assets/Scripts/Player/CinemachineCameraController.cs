using Cinemachine;

namespace ITB.Player
{
    public class CinemachineCameraController
    {
        private Player player;
        private CinemachineVirtualCamera cinemachineVirtualCamera;
        
        public CinemachineCameraController(Player player, CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            this.player = player;
            this.cinemachineVirtualCamera = cinemachineVirtualCamera;
            
            cinemachineVirtualCamera.Follow = player.CameraLookTransform;
        }
    }
}