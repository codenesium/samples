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
    <Hash>bdbfac038e62d8f1ca316a28b3ff0c9d</Hash>
</Codenesium>*/