using AD_Project.Models.Departments;
using AD_Project.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AD_Project.ViewModel
{
    public class RetrievalFormViewModel
    {
      //  public List<ConsolidatedRequisition> RequisitionFromDept { get; set; }
      //  public List<CollectionOfRequestedItems> CollectionOfRequested { get; set; }

        public List<DeptRequestedItems> deptRequestedItems { get; set; }
        public List<StoreRetrievalList> storeRetrievalLists { get; set; }

    }
}