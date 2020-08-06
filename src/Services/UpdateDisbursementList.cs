using AD_Project.DbContext;
using AD_Project.Models.Store;
using AD_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AD_Project.Services
{
    public class UpdateDisbursementList
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void UpdateDisbursement(List<DeptRequestedItems> DeptList, RetrievalFormViewModel retrievalFormViewModel)
        {
            
            List<DisbursementList> disburseDeptList = new List<DisbursementList>();          
            List<int> deptId = new List<int>();

            foreach (var j in DeptList)
            {
                List<DisburseItem> disburseList = new List<DisburseItem>();
                DisburseItem disburseItemObj = new DisburseItem();
                disburseItemObj.ItemId = j.itemId;
                foreach (var f in retrievalFormViewModel.deptRequestedItems)
                {
                    if ((j.itemId == f.itemId) && (j.DeptId == f.DeptId))
                    {
                        disburseItemObj.DisburseQty = f.ActualDeliveredQtyForEachItem;
                    }
                }

                db.DisburseItems.Add(disburseItemObj);
                disburseList.Add(disburseItemObj);
                if (deptId.Contains(j.DeptId))
                {

                    // var disburseDept = disburseDeptList.Find(m => m.DeptId == j.DeptId);
                    var disburseDept = db.DisbursementLists.SingleOrDefault(m => m.DeptId == j.DeptId);
                    disburseDept.DisburseItems.Add(disburseItemObj);
                 //   disburseDept.DisburseItems = disburseList;
                    disburseDept.DisbursementListDate = DateTime.Now;
                  //  disburseDept.Status = "pending";
                   // db.DisbursementLists.Add(disburseDept);
                }
                else
                {
                    deptId.Add(j.DeptId);
                    
                    DisbursementList disburseListObj = new DisbursementList();
                    disburseListObj.DeptId = j.DeptId;
                    disburseListObj.DisburseItems = disburseList;
                    disburseListObj.DisbursementListDate = DateTime.Now;
                    disburseListObj.Status = "pending";
                    //  disburseDeptList.Add(disburseListObj);
                    db.DisbursementLists.Add(disburseListObj);

                }

                
                db.SaveChanges();
            }
        }
    }
}