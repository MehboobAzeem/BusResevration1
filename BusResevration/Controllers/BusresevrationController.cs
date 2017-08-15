using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusResevration.Controllers
{
    public class BusresevrationController : ApiController
    {
        BusReservationDbEntities db = new BusReservationDbEntities();

        [HttpGet]
        [Route("api/BusresevrationController/NewUser")]
        public bool NewUser(User u)
        {
            if (u != null)
            {
                db.Users.Add(u);
                db.SaveChanges();

                return true;
            }
            return false;
        }

        [HttpGet]
        [Route("api/BusresevrationController/Resevration")]
        public bool Resevration(Resevration r)
        {
            if (r != null)
            {
                db.Resevrations.Add(r);
                db.SaveChanges();

                return true;
            }
            return false;
        }

        [HttpGet]
        [Route("api/BusresevrationController/CheckReservtionsStatus")]
        public string CheckReservtionsStatus(int ticketNumber)
        {
            Resevration r = new Resevration();
            return r.CurrentStatus;
        }
        [HttpGet]
        [Route("api/BusresevrationController/CancelResevrtion")]
        public bool CancelResevrtion(int ReservationId)
        {
            Resevration rs = db.Resevrations.Find(ReservationId);
            rs.CurrentStatus = "cancel";
            db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        [HttpGet]
        [Route("api/BusresevrationController/getResevrtions")]
        public List<Resevration>getResevrtions()
        {
            List<Resevration> resevrtions = new List<Resevration>();
            resevrtions = db.Resevrations.ToList();
            return resevrtions;
        } 


    }
}
