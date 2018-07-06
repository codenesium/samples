using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductListPriceHistoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productID,
                        DateTime? endDate,
                        decimal listPrice,
                        DateTime modifiedDate,
                        DateTime startDate)
                {
                        this.ProductID = productID;
                        this.EndDate = endDate;
                        this.ListPrice = listPrice;
                        this.ModifiedDate = modifiedDate;
                        this.StartDate = startDate;
                }

                public DateTime? EndDate { get; private set; }

                public decimal ListPrice { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a53a4cabe58fc943a70eb2ef5d8bb660</Hash>
</Codenesium>*/