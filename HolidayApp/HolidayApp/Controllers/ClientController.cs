﻿using HolidayApp.Abstract;
using HolidayApp.Entities;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayApp.Controllers
{
    public class ClientController : Controller
    {


        private IHolidaysRepository repository;

        public ClientController(IHolidaysRepository repoparam)
        {

            repository = repoparam;

        }




        public ActionResult BookHolidayHome(int Id)
        {
            HolidayHome model = repository.GetHolidayHomeById(Id);
         List<DateTime> list= repository.GetDaysBookedHolidayHome(Id);
            List<string> liststring = new List<string>();

            foreach (var item in list)
            {
                liststring.Add(item.ToShortDateString());
            }

            BookViewModel viewmodel = new BookViewModel();
            viewmodel.holidayhome = model;
            viewmodel.list = liststring;

            return View(viewmodel);
        }

        public ActionResult BookRoom(int Id)
        {
            Room model = repository.GetRoomById(Id);
            List<DateTime> list = repository.GetDaysBookedRoom(Id);
            List<string> liststring = new List<string>();

            foreach (var item in list)
            {
                liststring.Add(item.ToShortDateString());
            }

            BookRoomViewModel viewmodel = new BookRoomViewModel();
            viewmodel.room = model;
            viewmodel.list = liststring;

            return View(viewmodel);
        }



        //public ActionResult ShowWhenBooked(int Id)
        //{
        //    return PartialView();
        //}


        //public ActionResult ReserveRoom()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult ReserveHolidayHome(ReverveHolidayHomeModel model)
        {

           if(model.dateTo<=model.dateFrom)
            {
                ModelState.AddModelError("dateTo", "Date should be later than above");
            }

            if(model.dateFrom==null)
            {
                ModelState.AddModelError("dateFrom", "Pole nie moze być puste");
            }


            if(ModelState.IsValid)
            {
                //repository.BookHolidayHome(model.holidayhomeId, model.dateFrom, model.dateTo);

                CheckBookingModel modelbook = repository.bookholidayhome(model.holidayhomeId, model.dateFrom, model.dateTo);
                ViewBag.checkbookingmodel = modelbook;

 return RedirectToAction("ShowDetailsHolidayHome","Home",new {Id=model.holidayhomeId });
            }
            else
            {
                HolidayHome holidayhome= repository.GetHolidayHomeById(model.holidayhomeId);
                List<DateTime> list = repository.GetDaysBookedHolidayHome(model.holidayhomeId);
                List<string> liststring = new List<string>();

                foreach (var item in list)
                {
                    liststring.Add(item.ToShortDateString());
                }

                BookViewModel viewmodel = new BookViewModel();
                viewmodel.holidayhome = holidayhome;
                viewmodel.list = liststring;





                //return View("~/Views/Client/Book/HolidayHome.cshtml", viewmodel);
                return View("~/Views/Client/BookHolidayHome.cshtml", viewmodel);


            }



           
        }

        [HttpPost]
        public ActionResult ReserveRoom(ReverveRoomModel model)
        {

            if (model.dateTo <= model.dateFrom)
            {
                ModelState.AddModelError("dateTo", "Date should be later than above");
            }

            if (model.dateFrom == null)
            {
                ModelState.AddModelError("dateFrom", "Pole nie moze być puste");
            }


            if (ModelState.IsValid)
            {
                //repository.BookHolidayHome(model.holidayhomeId, model.dateFrom, model.dateTo);

                CheckBookingModel modelbook = repository.bookroom(model.roomId, model.dateFrom, model.dateTo);
                ViewBag.checkbookingmodel = modelbook;

                return RedirectToAction("ShowDetailsRoom", "Home", new { Id = model.roomId });
            }
            else
            {
                Room room = repository.GetRoomById(model.roomId);
                List<DateTime> list = repository.GetDaysBookedRoom(model.roomId);
                List<string> liststring = new List<string>();

                foreach (var item in list)
                {
                    liststring.Add(item.ToShortDateString());
                }

                BookRoomViewModel viewmodel = new BookRoomViewModel();
                viewmodel.room = room;
                viewmodel.list = liststring;

                return View("~/Views/Client/BookRoom.cshtml", viewmodel);



                //Room room = repository.GetRoomById(model.roomId);
                //return View("~/Views/Client/BookRoom.cshtml", room);



            }




        }


    }
}