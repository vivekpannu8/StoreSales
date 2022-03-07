using System;
public class Ride
{
	private int rideId;
	private string pickupLocation;
	private string destination;
	private decimal fare;
	private string allotedDriverId;
	private string allotedPassengerId;


	protected string getPickupLocation() { }
	protected string setPickupLocation() { }
	protected string getDestination() { }
	protected string setDestination() { }
	protected string setFare() { }
	protected string getFare() { }
	protected string getRideId() { }
	protected string setRideId() { }
	protected getAllotedDriverId() { }
	protected setAllotedDriverId() { }
	protected getAllotedPassengerId() { }
	protected setAllotedPassengerId() { }
}

public class Driver : Ride
{
	private int driverId;
	private string driverName;
	private string driverAddress;
	private string driverAadharCard;
	private string driverPhone;
	private string driverVehicleName;
	private string driverVehicleModel;
	private string driverCurrentLocation;

	public bool isDriverFree()
    {
		// To know if the driver is free to go for a ride
    }
	public void bookRide
}

public class Passenger : Ride
{
	private int passengerId;
	private string passengerName;
	private string passengerCurrentLocation;
	private string passengerPhone;

	public void bookRide() { }
}

