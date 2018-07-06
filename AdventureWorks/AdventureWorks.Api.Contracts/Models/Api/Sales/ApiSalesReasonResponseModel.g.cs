using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesReasonResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int salesReasonID,
                        DateTime modifiedDate,
                        string name,
                        string reasonType)
                {
                        this.SalesReasonID = salesReasonID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ReasonType = reasonType;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public string ReasonType { get; private set; }

                public int SalesReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c347781421a60e793691323c6515694c</Hash>
</Codenesium>*/