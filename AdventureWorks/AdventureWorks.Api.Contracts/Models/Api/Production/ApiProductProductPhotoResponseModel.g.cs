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

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public bool Primary { get; private set; }

                [JsonProperty]
                public int ProductID { get; private set; }

                [JsonProperty]
                public int ProductPhotoID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9d0328bcad87be4d8d5b5c77774a4bc1</Hash>
</Codenesium>*/