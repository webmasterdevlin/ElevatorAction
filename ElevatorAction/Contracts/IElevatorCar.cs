namespace ElevatorAction.Contracts;

public interface IElevatorCar
{
    void SetFloorOnEmergency(int floor);
    void GenerateNewRequestedFloor();
    void OpenDoor();
    void ShuttingDoor();
}