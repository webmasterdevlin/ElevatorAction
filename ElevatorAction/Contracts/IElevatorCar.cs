namespace ElevatorAction.Contracts;

public interface IElevatorCar
{
    void SetFloorOnEmergency(int floor);
    void GenerateNewRequestedFloor();
    void OpenDoors();
    void ShuttingDoor();
}