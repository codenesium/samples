using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductCategoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productCategoryID,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.ProductCategoryID = productCategoryID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductCategoryID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a16772af21a6034897862c4df5826a55</Hash>
</Codenesium>*/