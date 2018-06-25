using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiWorkOrderRequestModel : AbstractApiRequestModel
        {
                public ApiWorkOrderRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime dueDate,
                        DateTime? endDate,
                        DateTime modifiedDate,
                        int orderQty,
                        int productID,
                        short scrappedQty,
                        short? scrapReasonID,
                        DateTime startDate,
                        int stockedQty)
                {
                        this.DueDate = dueDate;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.ScrappedQty = scrappedQty;
                        this.ScrapReasonID = scrapReasonID;
                        this.StartDate = startDate;
                        this.StockedQty = stockedQty;
                }

                private DateTime dueDate;

                [Required]
                public DateTime DueDate
                {
                        get
                        {
                                return this.dueDate;
                        }

                        set
                        {
                                this.dueDate = value;
                        }
                }

                private DateTime? endDate;

                public DateTime? EndDate
                {
                        get
                        {
                                return this.endDate;
                        }

                        set
                        {
                                this.endDate = value;
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

                private int orderQty;

                [Required]
                public int OrderQty
                {
                        get
                        {
                                return this.orderQty;
                        }

                        set
                        {
                                this.orderQty = value;
                        }
                }

                private int productID;

                [Required]
                public int ProductID
                {
                        get
                        {
                                return this.productID;
                        }

                        set
                        {
                                this.productID = value;
                        }
                }

                private short scrappedQty;

                [Required]
                public short ScrappedQty
                {
                        get
                        {
                                return this.scrappedQty;
                        }

                        set
                        {
                                this.scrappedQty = value;
                        }
                }

                private short? scrapReasonID;

                public short? ScrapReasonID
                {
                        get
                        {
                                return this.scrapReasonID;
                        }

                        set
                        {
                                this.scrapReasonID = value;
                        }
                }

                private DateTime startDate;

                [Required]
                public DateTime StartDate
                {
                        get
                        {
                                return this.startDate;
                        }

                        set
                        {
                                this.startDate = value;
                        }
                }

                private int stockedQty;

                [Required]
                public int StockedQty
                {
                        get
                        {
                                return this.stockedQty;
                        }

                        set
                        {
                                this.stockedQty = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>0b91a73c0443f70d6dd4567c34a8ed2f</Hash>
</Codenesium>*/