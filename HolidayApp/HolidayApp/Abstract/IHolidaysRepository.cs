﻿using HolidayApp.Models;
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




    }
}