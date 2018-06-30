using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPurchaseOrderHeaderRequestModel : AbstractApiRequestModel
        {
                public ApiPurchaseOrderHeaderRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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

                private int employeeID;

                [Required]
                public int EmployeeID
                {
                        get
                        {
                                return this.employeeID;
                        }

                        set
                        {
                                this.employeeID = value;
                        }
                }

                private decimal freight;

                [Required]
                public decimal Freight
                {
                        get
                        {
                                return this.freight;
                        }

                        set
                        {
                                this.freight = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private DateTime orderDate;

                [Required]
                public DateTime OrderDate
                {
                        get
                        {
                                return this.orderDate;
                        }

                        set
                        {
                                this.orderDate = value;
                        }
                }

                private int revisionNumber;

                [Required]
                public int RevisionNumber
                {
                        get
                        {
                                return this.revisionNumber;
                        }

                        set
                        {
                                this.revisionNumber = value;
                        }
                }

                private DateTime? shipDate;

                public DateTime? ShipDate
                {
                        get
                        {
                                return this.shipDate;
                        }

                        set
                        {
                                this.shipDate = value;
                        }
                }

                private int shipMethodID;

                [Required]
                public int ShipMethodID
                {
                        get
                        {
                                return this.shipMethodID;
                        }

                        set
                        {
                                this.shipMethodID = value;
                        }
                }

                private int status;

                [Required]
                public int Status
                {
                        get
                        {
                                return this.status;
                        }

                        set
                        {
                                this.status = value;
                        }
                }

                private decimal subTotal;

                [Required]
                public decimal SubTotal
                {
                        get
                        {
                                return this.subTotal;
                        }

                        set
                        {
                                this.subTotal = value;
                        }
                }

                private decimal taxAmt;

                [Required]
                public decimal TaxAmt
                {
                        get
                        {
                                return this.taxAmt;
                        }

                        set
                        {
                                this.taxAmt = value;
                        }
                }

                private decimal totalDue;

                [Required]
                public decimal TotalDue
                {
                        get
                        {
                                return this.totalDue;
                        }

                        set
                        {
                                this.totalDue = value;
                        }
                }

                private int vendorID;

                [Required]
                public int VendorID
                {
                        get
                        {
                                return this.vendorID;
                        }

                        set
                        {
                                this.vendorID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d2c152acb5d3898e6409d2abfa73eab2</Hash>
</Codenesium>*/