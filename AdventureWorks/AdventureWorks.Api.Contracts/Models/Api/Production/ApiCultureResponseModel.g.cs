using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCultureResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string cultureID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [JsonProperty]
                public string CultureID { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e13324eb034685ea3916f394534fa529</Hash>
</Codenesium>*/