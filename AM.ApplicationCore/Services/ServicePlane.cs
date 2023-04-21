using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Domain;
using System.Collections.Generic;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

            
        }

        public void DeletePlane()
        {
           //Delete(p=>p.ManufactureDate.AddYears(10).Year < DateTime.Now.Year);
            Delete(p => DateTime.Now.Year - p.ManufactureDate.Year > 10);
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll().OrderByDescending(p=>p.PlaneId).Take(n).SelectMany(p=>p.Flights).OrderBy(f=>f.FlightDate).ToList();
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
            return GetById(plane.PlaneId).Flights.SelectMany(f => f.Tickets.Select(t => t.Passenger)).ToList();

        }

        public bool IsAvailablePlane(Flight flight, int n )
        {
            int planeCapacity = flight.Plane.Capacity;
            int nbrTickets = flight.Tickets.Count;
            return planeCapacity >= nbrTickets + n;
        }
    }
}
