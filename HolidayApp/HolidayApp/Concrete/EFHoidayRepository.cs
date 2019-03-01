﻿using HolidayApp.Abstract;
using HolidayApp.Entities;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace HolidayApp.Concrete
{
    public class EFHolidayRepository : IHolidaysRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public bool AddHolidayHomeToResort(HolidayHome holidayhome, int id)
        {



            try
            {
                Resort resort = context.Resorts.Find(id);
                resort.HolidayHomes.Add(holidayhome);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }



        }

        public bool AddHotel(Hotel hotel, string UserId)
        {

            try
            {
                ApplicationUser user = context.Users.Find(UserId);

                user.Hotels.Add(hotel);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public bool AddParkingToHotel(Parking parking, int id)
        {

            try
            {
                Hotel hotel = context.Hotels.Find(id);
                hotel.Parkings.Add(parking);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }



        }

        public bool AddParkingToResort(Parking parking, int id)
        {
            try
            {
                Resort resort = context.Resorts.Find(id);
                resort.Parkings.Add(parking);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool AddResort(Resort resort, string UserId)
        {

            try
            {
                ApplicationUser user = context.Users.Find(UserId);

                user.Resorts.Add(resort);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }






        }

        public bool AddRoomToHotel(Room room, int id)
        {
            try
            {
                Hotel hotel = context.Hotels.Find(id);
                hotel.Rooms.Add(room);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }




        }

        public bool AddRoomToResort(Room room, int id)
        {

            try
            {
                Resort resort = context.Resorts.Find(id);
                resort.Rooms.Add(room);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }




        }

        public bool ChangeHotel(Hotel hotel)
        {

            Hotel hotelChange = context.Hotels.Find(hotel.HotelId);
            hotelChange.Name = hotel.Name;
            hotelChange.City = hotel.City;
            hotelChange.Country = hotel.Country;
            hotelChange.TelephoneNumber = hotel.TelephoneNumber;
            context.SaveChanges();
            return true;





        }

        public bool ChangeResort(Resort resort)
        {
            Resort resortChange = context.Resorts.Find(resort.ResortId);
            resortChange.Name = resort.Name;
            resortChange.City = resort.City;
            resortChange.Country = resort.Country;
            resortChange.TelephoneNumber = resort.TelephoneNumber;
            context.SaveChanges();
            return true;



        }

        public HolidayHome GetHolidayHomeById(int id)
        {
            try
            {
                HolidayHome holidayHome = context.HolidayHomes.Include("Resorts").Where(x => x.HolidayHomeId == id).First();
                return holidayHome;

            }
            catch
            {
                return new HolidayHome();
            }
        }

        public Hotel GetHotelByID(int id)
        {
            Hotel hotel = new Hotel();
            try
            {

                hotel = context.Hotels.Find(id);
                return hotel;

            }
            catch
            {
                return hotel;
            }


        }

        public HolidayViewModel GetModelByUser(string UserId)
        {

            List<Room> roomList = new List<Room>();
            List<Hotel> hotelList = new List<Hotel>();
            List<Resort> resortList = new List<Resort>();




            try
            {
                hotelList = context.Hotels.Include("Rooms").Where(x => x.ApplicationUserID == UserId).ToList();
            }
            catch
            {

            }

            try
            {
                resortList = context.Resorts.Include("Rooms").Where(x => x.ApplicationUserID == UserId).ToList();
            }
            catch
            {

            }



            if (hotelList.Count > 0)
            {

                foreach (var item in hotelList)
                {
                    try
                    {
                        roomList.AddRange(item.Rooms);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }


            }


            if (resortList.Count > 0)
            {

                foreach (var item in resortList)
                {
                    try
                    {
                        roomList.AddRange(item.Rooms);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }



            }






            HolidayViewModel model = new HolidayViewModel();

            model.ResortList = resortList;
            model.HotelList = hotelList;
            model.RoomList = roomList;



            return model;

        }

        public Parking GetParkingById(int id)
        {

            try
            {

                Parking parking = context.Parkings.Find(id);
                return parking;

            }
            catch
            {
                return new Parking();
            }



        }

        public HolidayViewModel GetRandomPlaces()
        {

            Random random = new Random();
            int countResort = 0;
            int countHotel = 0;
            int countRoom = 0;

            List<int> ResortNumber = new List<int>();
            List<int> HotelNumber = new List<int>();
            List<int> RoomNumber = new List<int>();

            HolidayViewModel viewModel = new HolidayViewModel();




            try
            {
                countResort = context.Resorts.Count();
                countHotel = context.Hotels.Count();
                countRoom = context.Rooms.Count();
            }
            catch (Exception ex)
            {

                return new HolidayViewModel();

            }



            for (int i = 0; i < 10; i++)
            {
                if (countResort > 0)
                {
                    ResortNumber.Add(random.Next(1, countResort));
                }

                if (countHotel > 0)
                {
                    HotelNumber.Add(random.Next(1, countHotel));
                }

                if (countRoom > 0)
                {
                    RoomNumber.Add(random.Next(1, countRoom));
                }


            }


            ResortNumber = ResortNumber.Distinct().Take(2).ToList();
            HotelNumber = HotelNumber.Distinct().Take(2).ToList();
            RoomNumber = RoomNumber.Distinct().Take(2).ToList();



            for (int i = 0; i < 2; i++)
            {


                try
                {
                    viewModel.HotelList.Add(context.Hotels.Find(HotelNumber[i]));
                }
                catch
                {
                    viewModel.HotelList.Add(new Hotel());
                }


                try
                {
                    viewModel.ResortList.Add(context.Resorts.Find(ResortNumber[i]));
                }
                catch
                {
                    viewModel.ResortList.Add(new Resort());
                }

                try
                {
                    viewModel.RoomList.Add(context.Rooms.Find(RoomNumber[i]));
                }
                catch
                {

                    viewModel.RoomList.Add(new Room());
                }


            }


            return viewModel;


        }

        public Resort GetResortByID(int id)
        {

            try
            {
                Resort resort = context.Resorts.Find(id);
                return resort;
            }
            catch
            {
                return new Resort();
            }


        }

        public Room GetRoomById(int id)
        {

            try
            {
                Room room = context.Rooms.Find(id);
                return room;

            }
            catch
            {
                return new Room();
            }
        }

        public bool RemoveHolidayHome(int id)
        {
            try
            {
                HolidayHome holidayHome = context.HolidayHomes.Find(id);
                context.HolidayHomes.Remove(holidayHome);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveHotel(int id)
        {

            try
            {

                Hotel hotel = context.Hotels.Find(id);


                List<Parking> parkingList = hotel.Parkings.ToList();
                List<Room> roomList = hotel.Rooms.ToList();
              
                if(parkingList.Count>0)
                {
                    foreach (var item in parkingList)
                    {
                        context.Parkings.Remove(item);
                        context.SaveChanges();
                    }

                }


                if(roomList.Count>0)
                {

                    foreach (var item in roomList)
                    {
                      context.Rooms.Remove(item);
                        context.SaveChanges();
                    }
                   


                }



                context.Hotels.Remove(hotel);
                context.SaveChanges();
                return true;






            }
            catch(Exception ex)
            {
                return false;
            }





        }

        public bool RemoveParking(int id)
        {


            try
            {
                Parking parking = context.Parkings.Find(id);
                context.Parkings.Remove(parking);
                context.SaveChanges();
                return true;

            }
            catch
            {

                return false;

            }

        }

        public bool RemoveResort(int id)
        {


            try
            {

                Resort resort = context.Resorts.Find(id);


                List<Parking> parkingList = resort.Parkings.ToList();
                List<Room> roomList = resort.Rooms.ToList();
                List<HolidayHome> holidayHomeList = resort.HolidayHomes.ToList();

                if (parkingList.Count > 0)
                {
                    foreach (var item in parkingList)
                    {
                        context.Parkings.Remove(item);
                        context.SaveChanges();
                    }

                }


                if (roomList.Count > 0)
                {

                    foreach (var item in roomList)
                    {
                        context.Rooms.Remove(item);
                        context.SaveChanges();
                    }



                }


                if(holidayHomeList.Count>0)
                {

                    foreach (var item in holidayHomeList)
                    {
                        context.HolidayHomes.Remove(item);
                        context.SaveChanges();
                    }


                }



                context.Resorts.Remove(resort);
                context.SaveChanges();
                return true;






            }
            catch (Exception ex)
            {
                return false;
            }










        }

        public bool RemoveRoom(int id)
        {


            try
            {
                Room room = context.Rooms.Find(id);
                context.Rooms.Remove(room);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }



        }
    }
}