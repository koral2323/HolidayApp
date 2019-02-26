﻿using HolidayApp.Entities;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Abstract
{
    public interface IHolidaysRepository
    {

        HolidayViewModel GetRandomPlaces();
        HolidayViewModel GetModelByUser(string UserId);
        bool AddResort(Resort resort,string UserId);
        bool AddHotel(Hotel hotel,string UserId);
        Hotel GetHotelByID(int id);
        bool ChangeHotel(Hotel hotel);
        Resort GetResortByID(int id);
        bool ChangeResort(Resort resort);
        bool RemoveRoom(int id);
        Room GetRoomById(int id);
        bool AddRoomToResort(Room room, int id);
        bool AddRoomToHotel(Room room, int id);
        //bool AddRoom(Resort resort, Room room);
        //bool AddRoom(Hotel hotel, Room room);
        //bool AddParking(Resort resort, Parking parking);
        //bool AddParking(Hotel hotel, Parking parking);
        //bool AddHolidayHome(Resort resort, HolidayHome holidayhome);




    }
}