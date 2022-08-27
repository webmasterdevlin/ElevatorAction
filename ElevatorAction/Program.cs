using ElevatorAction;

var e = new Elevator(9);
e.SetUserFloorOrigin(9);
// e.SetFloorOnEmergency(6); // uncomment this line to see the difference
e.GoToFloor(0);
Console.ReadLine();