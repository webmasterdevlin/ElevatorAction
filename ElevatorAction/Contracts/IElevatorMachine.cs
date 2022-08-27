namespace ElevatorAction.Contracts;

public interface IElevatorMachine
{
    string GetLiftDirection();
    int GetEstimatedTimeOfWaiting(int floorsDifference, int floorIntervalInSeconds);
    void EnableMultiFloorRequests();
    void GoToSpecifiedFloor();
    void GoToFloor(int floor);
    void SetUserFloorOrigin(int floor);
}