using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiIllustrationResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string diagram,
                        int illustrationID,
                        DateTime modifiedDate)
                {
                        this.Diagram = diagram;
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                }

                public string Diagram { get; private set; }

                public int IllustrationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDiagramValue { get; set; } = true;

                public bool ShouldSerializeDiagram()
                {
                        return this.ShouldSerializeDiagramValue;
                }

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

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDiagramValue = false;
                        this.ShouldSerializeIllustrationIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>520b266fefeb42c007adbf80077ddd03</Hash>
</Codenesium>*/