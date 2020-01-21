using System;
using System.Linq;
using System.Collections.Generic;

namespace ModasSeedData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // first create Locations list
            List<Location> Locations = new List<Location>()
            {
                new Location { LocationId = 0, Name = "Front Door"},
                new Location { LocationId = 1, Name = "Z Door"},
                new Location { LocationId = 2, Name = "Kitchen"},
                new Location { LocationId = 3, Name = "Ballroom"},
                // TODO: Add locations
            };
            // create date object containing current date/time
            DateTime localDate = DateTime.Now;
            // TODO: subtract 6 months from date
            DateTime eventDate = localDate.AddMonths(-6);
            // TODO: instantiate Random class
            // Random rnd = ???
            Random rnd = new Random();
            // TODO: create list to store events (Events)
            List<Event> listEvents = new List<Event>();
            // loop for each day in the range from 6 months ago to today
            int IDCounter = 0;
            while (eventDate < localDate)
            {
                List<Event> listEventDay = new List<Event>();
                // TODO: random between 0 and 5 determines the number of events to occur on a given day
                int randomNumber = rnd.Next(0, 6);
                // TODO: a sorted list will be used to store daily events sorted by date/time - each time an event is added, the list is re-sorted
                // TODO: for loop to generate times for each event
                Console.WriteLine("Generating Day: " + eventDate);

                for (int i = 0; i < randomNumber; i++)
                {

                    int hour = rnd.Next(0, 23);
                    int minute = rnd.Next(0, 59);
                    int second = rnd.Next(0, 59);
                    int rndLocation = rnd.Next(0, Locations.Count);
                    Location location = Locations[rndLocation];
                    DateTime newDate = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, hour, minute, second);
                    Event newEvent = new Event();
                    newEvent.TimeStamp = newDate;
                    newEvent.LocationId = location.LocationId;
                    newEvent.EventId = IDCounter;
                    newEvent.Location = location;
                    IDCounter++;
                    //logic is that it is already sorted during each run, we just have to find where this event goes
                    listEventDay.Add(newEvent);
                    listEventDay.Sort((x, y) => DateTime.Compare(x.TimeStamp, y.TimeStamp));
                    
                }
                // TODO: random between 0 and 23 for hour of the day
                // TODO: random between 0 and 59 for minute of the day
                // TODO: random between 0 and 59 for seconds of the day
                // TODO: random location (use Locations)
                // TODO: create date/time for event
                // TODO: create event from date/time and location
                // TODO: add daily event to sorted list
                // TODO: loop thru sorted list for daily events
                // add daily event to Events
                // TODO: add 1 day to eventDate
                foreach (Event tempEvent in listEventDay)
                {
                    listEvents.Add(tempEvent);
                }
                eventDate = eventDate.AddDays(1);

            }

            // TODO: loop thru Events
            // TODO: display event at console

            foreach (Event tempEvent in listEvents)
            {
                Console.WriteLine("Event ID: " + tempEvent.EventId);
                Console.WriteLine("Location ID: " + tempEvent.LocationId);
                Console.WriteLine("Date Time: " + tempEvent.TimeStamp);
                Console.WriteLine("Location: " + tempEvent.LocationId);
                Console.WriteLine("----------------------------");



            }
        }
    }

    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Flagged { get; set; }
        // foreign key for location 
        public int LocationId { get; set; }
        // navigation property
        public Location Location { get; set; }
    }
}
