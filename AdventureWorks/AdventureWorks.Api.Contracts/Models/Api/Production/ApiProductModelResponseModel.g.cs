using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productModelID,
                        string catalogDescription,
                        string instructions,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.ProductModelID = productModelID;
                        this.CatalogDescription = catalogDescription;
                        this.Instructions = instructions;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                public string CatalogDescription { get; private set; }

                public string Instructions { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductModelID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2f067b2638695674067c062e778debfc</Hash>
</Codenesium>*/