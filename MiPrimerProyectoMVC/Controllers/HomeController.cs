﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.IO;
using MiPrimerProyectoMVC.Tags;
using Helper;
using Model.Commons;

namespace MiPrimerProyectoMVC.Controllers
{
    [AutenticadoAttribute]
    public class HomeController : Controller
    {
       

        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult Salir()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }
    }
}