using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductProductPhotoResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productID,
                        DateTime modifiedDate,
                        bool primary,
                        int productPhotoID)
                {
                        this.ProductID = productID;
                        this.ModifiedDate = modifiedDate;
                        this.Primary = primary;
                        this.ProductPhotoID = productPhotoID;
                }

                public DateTime ModifiedDate { get; private set; }

                public bool Primary { get; private set; }

                public int ProductID { get; private set; }

                public int ProductPhotoID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1556221d2ea4fddf3c4eff9f01536b71</Hash>
</Codenesium>*/