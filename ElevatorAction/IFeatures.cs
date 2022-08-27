namespace ElevatorAction;

public interface IFeatures
{
    void GoToSpecifiedFloor();
    string GetLiftDirection();
    int GetEstimatedTimeOfWaiting(int floorsDifference);
    void SetFloorOnEmergency(int floor);
    void EnableMultiFloorRequests();
}