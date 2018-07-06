using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPurchaseOrderHeaderResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int purchaseOrderID,
                        int employeeID,
                        decimal freight,
                        DateTime modifiedDate,
                        DateTime orderDate,
                        int revisionNumber,
                        DateTime? shipDate,
                        int shipMethodID,
                        int status,
                        decimal subTotal,
                        decimal taxAmt,
                        decimal totalDue,
                        int vendorID)
                {
                        this.PurchaseOrderID = purchaseOrderID;
                        this.EmployeeID = employeeID;
                        this.Freight = freight;
                        this.ModifiedDate = modifiedDate;
                        this.OrderDate = orderDate;
                        this.RevisionNumber = revisionNumber;
                        this.ShipDate = shipDate;
                        this.ShipMethodID = shipMethodID;
                        this.Status = status;
                        this.SubTotal = subTotal;
                        this.TaxAmt = taxAmt;
                        this.TotalDue = totalDue;
                        this.VendorID = vendorID;
                }

                public int EmployeeID { get; private set; }

                public decimal Freight { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public DateTime OrderDate { get; private set; }

                public int PurchaseOrderID { get; private set; }

                public int RevisionNumber { get; private set; }

                public DateTime? ShipDate { get; private set; }

                public int ShipMethodID { get; private set; }

                public int Status { get; private set; }

                public decimal SubTotal { get; private set; }

                public decimal TaxAmt { get; private set; }

                public decimal TotalDue { get; private set; }

                public int VendorID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5b0e54be24eaef71f2e804b9eb9a084d</Hash>
</Codenesium>*/