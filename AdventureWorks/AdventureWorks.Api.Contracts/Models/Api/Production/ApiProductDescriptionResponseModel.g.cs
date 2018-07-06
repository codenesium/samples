using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductDescriptionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productDescriptionID,
                        string description,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.ProductDescriptionID = productDescriptionID;
                        this.Description = description;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                public string Description { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductDescriptionID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8b9d0b7afc749f2d5ff694746fb95cf7</Hash>
</Codenesium>*/