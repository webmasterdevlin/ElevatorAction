using ElevatorAction;

var e = new Elevator(9);
e.SetUserFloorOrigin(1);
// e.SetFloorOnEmergency(6); // uncomment this line to see the difference
e.EnableMultiFloorRequests();

e.GoToFloor(8);
Console.ReadLine();