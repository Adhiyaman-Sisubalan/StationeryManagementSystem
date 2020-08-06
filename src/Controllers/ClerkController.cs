using AD_Project.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AD_Project.ViewModel;
using System.Diagnostics;
using AD_Project.Models.Store;
using AD_Project.Models.Departments;
using AD_Project.Services;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace AD_Project.Controllers
{
    [Authorize(Roles = "1")]
    public class ClerkController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayRequestedItems()
        {
            var reqs = db.ConsolidatedRequisitions.Include(c => c.Department).Where(h => h.ConsolidatedRequisitionStatus == "Approved").ToList();
            return View(reqs);
        }
        public ActionResult RequestOfEachDept(int id)
        {
            var requestedDeptDetails = db.ConsolidatedRequisitions.Include(i => i.CollectionOfReq.Select(it => it.Item))
                .SingleOrDefault(m => m.ConsolidatedRequisitionId == id);

            return View(requestedDeptDetails);
        }

        public ActionResult RetrievalForm()
        {
            DisplayRetrievalForm dis = new DisplayRetrievalForm();
            return View(dis.DisplayRetrieval());
        }

        //Saif

        public ActionResult DisburmentList()
        {
            List<Department> departments = db.Departments.ToList();

            var disbursementViewModel = new DisbursementViewModel();
            disbursementViewModel.DisbursementList = new DisbursementList();
            disbursementViewModel.DisbursementList.DisburseItems = new List<DisburseItem>();
            disbursementViewModel.Departments = departments;

            return View(disbursementViewModel);
        }

        public ActionResult DisplayDisburmentList(DisbursementViewModel disbursementViewModel)
        {
            List<Department> departments = db.Departments.ToList();
            disbursementViewModel.DisbursementList = new DisbursementList();
            disbursementViewModel.DisbursementList.DisburseItems = new List<DisburseItem>();
            var disburmentList = db.DisbursementLists.Include(m => m.DisburseItems
            .Select(a => a.Item))
            .FirstOrDefault(m => m.Department.DeptId == disbursementViewModel.SelectedDepId && m.Status == "pending");


            try
            {
                if (disburmentList.DisburseItems.Count != 0)
                {
                    if (disburmentList.Status == "pending")
                    {
                        disbursementViewModel.DisbursementList = disburmentList;
                    }
                }
                disbursementViewModel.Departments = departments;
                if (disburmentList != null)
                {
                    return View("DisburmentList", disbursementViewModel);
                }
                else
                {
                    return RedirectToAction("DisburmentList");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("DisburmentList");
            }
        }

        [HttpPost]
        public ActionResult UpdateRetrievalList(RetrievalFormViewModel retrievalFormViewModel)
        {
           
            List<DeptRequestedItems> DeptList;
            DisplayRetrievalForm dis = new DisplayRetrievalForm();
            RetrievalFormViewModel ret = dis.DisplayRetrieval();
            DeptList = ret.deptRequestedItems;
            UpdateDisbursementList d = new UpdateDisbursementList();
            d.UpdateDisbursement(DeptList, retrievalFormViewModel);

          /*  var deptActual = db.DeptRequestedItems.ToList();
            foreach(var g in deptActual)
            {
                RetrievalList retrievalList = new RetrievalList();
                retrievalList.DeptId = g.DeptId;
                retrievalList.ItemId = g.itemId;
                retrievalList.RequestedQty = g.DeptRequestedQtyForEachItem;
                string str = "ActualQty" + g.itemId + g.DeptId;
                retrievalList.ActualQty = Convert.ToInt32(form["str"]);
                db.RetrievalLists.Add(retrievalList);
            }*/
            db.SaveChanges();           
            return RedirectToAction("DisburmentList");

        }

    }
}