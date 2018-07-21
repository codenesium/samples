using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelIllustrationRequestModel : AbstractApiRequestModel
        {
                public ApiProductModelIllustrationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int illustrationID,
                        DateTime modifiedDate)
                {
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                }

                [Required]
                [JsonProperty]
                public int IllustrationID { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>09b5fe1c53fee06666c2f30017140cab</Hash>
</Codenesium>*/