using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiIllustrationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int illustrationID,
                        string diagram,
                        DateTime modifiedDate)
                {
                        this.IllustrationID = illustrationID;
                        this.Diagram = diagram;
                        this.ModifiedDate = modifiedDate;
                }

                [Required]
                [JsonProperty]
                public string Diagram { get; private set; }

                [JsonProperty]
                public int IllustrationID { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>53a667e13396fe8cc3b9e548d1d760ca</Hash>
</Codenesium>*/