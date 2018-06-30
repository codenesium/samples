using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelIllustrationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productModelID,
                        int illustrationID,
                        DateTime modifiedDate)
                {
                        this.ProductModelID = productModelID;
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                }

                public int IllustrationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductModelID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIllustrationIDValue { get; set; } = true;

                public bool ShouldSerializeIllustrationID()
                {
                        return this.ShouldSerializeIllustrationIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductModelIDValue { get; set; } = true;

                public bool ShouldSerializeProductModelID()
                {
                        return this.ShouldSerializeProductModelIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIllustrationIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductModelIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>b9b4631add16f83205ab5a683475581d</Hash>
</Codenesium>*/