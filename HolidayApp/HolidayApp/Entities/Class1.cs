﻿using HolidayApp.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Entities
{

    public interface IAddImage
    {
        string AddPathToEntity(int Id, string Path);
    }






    public class Image
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }


        public virtual Resort Resort { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual Room Room { get; set; }

        public virtual HolidayHome HolidayHome { get; set; }

        public virtual Parking Parking { get; set; }

       
    }






    public class Resort : IAddImage
    {

        IHolidaysRepository repository;

       
        public Resort()
        {
            Images = new HashSet<Image>();
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();
            HolidayHomes = new HashSet<HolidayHome>();
        }


        public Resort(IHolidaysRepository  repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();
            HolidayHomes = new HashSet<HolidayHome>();
        }

        public int ResortId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelephoneNumber { get; set; }

        public string ApplicationUserID { get; set; }
        public Models.ApplicationUser ApplicationUser { get; set; }


        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
        public virtual ICollection<HolidayHome> HolidayHomes { get; set; }

        public string AddPathToEntity(int Id, string Path)
        {
           return repository.AddPictureResort(Id, Path);
        }
    }



    public class Hotel : IAddImage
    {
        IHolidaysRepository repository;
        public Hotel(IHolidaysRepository repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();

        }

        public Hotel()
        {
            Images = new HashSet<Image>();
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();
        }

        public string AddPathToEntity(int Id, string Path)
        {
            return repository.AddPictureHotel(Id, Path);
        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelephoneNumber { get; set; }


        public  string ApplicationUserID { get; set; }
        public Models.ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }



    public class Room : IAddImage
    {
        IHolidaysRepository repository;
        public Room(IHolidaysRepository repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
        }
        public Room()
        {
            Images = new HashSet<Image>();
        }
        public string AddPathToEntity(int Id, string Path)
        {
            return repository.AddPictureRoom(Id, Path);
        }

        public int RoomId { get; set; }

        public decimal Price { get; set; }

        public int numberofGuests { get; set; }

        public int numberofBeds { get; set; }

        public bool doubleBed { get; set; }
                
        public bool petsAllowed { get; set; }
        
        public bool Kitchen { get; set; }

        public bool Toilet { get; set; }

        public int  numberofTelevisions{get;set;}


        public virtual ICollection<Image> Images { get; set; }
        //public int ResortId { get; set; }
        public virtual Resort Resort { get; set; }

        //public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

    }



    public class HolidayHome : IAddImage
    {
        IHolidaysRepository repository;
        public HolidayHome(IHolidaysRepository repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
        }
        public HolidayHome()
        {
            Images = new HashSet<Image>();
        }

        public string AddPathToEntity(int Id, string Path)
        {
            return repository.AddPictureHolidayHome(Id, Path);
        }
        public int HolidayHomeId { get; set; }

        public decimal Price { get; set; }

        public int numberofGuests { get; set; }

        public int numberofBeds { get; set; }

        public bool doubleBed { get; set; }

        public bool petsAllowed { get; set; }

        public bool Kitchen { get; set; }

        public bool Toilet { get; set; }

        public int numberofTelevisions { get; set; }

        public int numberofFloors { get; set; }






        public virtual ICollection<Image> Images { get; set; }
        //public int ResortId { get; set; }
        public virtual Resort Resort { get; set; }

        

    }



    public class Parking : IAddImage
    {
        IHolidaysRepository repository;
        public Parking(IHolidaysRepository repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
        }
        public Parking()
        {
            Images = new HashSet<Image>();
        }

        public string AddPathToEntity(int Id, string Path)
        {
            return repository.AddPictureParking(Id, Path);
        }
        public int ParkingId { get; set; }

        public int parkingPlaces { get; set; }

        public decimal pricePerDay { get; set; }

        public bool Guarded { get; set; }


        public virtual ICollection<Image> Images { get; set; }
        //public int ResortId { get; set; }
        public virtual Resort Resort { get; set; }

        //public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }


    }









}