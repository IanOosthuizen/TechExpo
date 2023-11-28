using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechSPO.Models;

namespace TechSPO.Controllers
{


    public class ReviewsController : Controller
    {
        private TechspoContext db = new TechspoContext();
        public IActionResult Reviews()
        {
            TechSPO.Models.Event details = new TechSPO.Models.Event();
            List<Event> listCat = ListEvent();

            ViewBag.EventId = new SelectList(listCat, "EventId", "EventName");
            details.list = ViewBag.EventId;

            TechSPO.Models.Session Sesstiondetails = new TechSPO.Models.Session();
            List<Session> ListS = ListSession();

            ViewBag.SessionId = new SelectList(ListS, "SessionId", "SessionName");
            Sesstiondetails.ListS = ViewBag.SessionId;


            return View();
        }

        [HttpPost]
        public IActionResult Reviews(TechSPO.Models.Review review)
        {

            review.ReviewDate = DateTime.Now;
            db.Reviews.Add(review);
            db.SaveChanges();

            return View();
        }

        public IActionResult ViewReviewTable()
        {

            using (db = new TechspoContext())
            {
                var listReviews = db.Reviews.ToList();
                return View(listReviews);
            }
        }


        private List<Event> ListEvent()
        {
            using (db = new TechspoContext())
            {
                var query = from a in db.Events
                            orderby a.EventName
                            select a;

                return query.ToList();
            }
        }

        private List<Session> ListSession()
        {
            using (db = new TechspoContext())
            {
                var query = from a in db.Sessions
                            orderby a.SessionName
                            select a;

                return query.ToList();
            }
        }

    }
}