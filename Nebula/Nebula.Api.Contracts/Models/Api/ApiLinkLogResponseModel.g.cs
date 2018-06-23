using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public class ApiLinkLogResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime dateEntered,
                        int id,
                        int linkId,
                        string log)
                {
                        this.DateEntered = dateEntered;
                        this.Id = id;
                        this.LinkId = linkId;
                        this.Log = log;

                        this.LinkIdEntity = nameof(ApiResponse.Links);
                }

                public DateTime DateEntered { get; private set; }

                public int Id { get; private set; }

                public int LinkId { get; private set; }

                public string LinkIdEntity { get; set; }

                public string Log { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDateEnteredValue { get; set; } = true;

                public bool ShouldSerializeDateEntered()
                {
                        return this.ShouldSerializeDateEnteredValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLinkIdValue { get; set; } = true;

                public bool ShouldSerializeLinkId()
                {
                        return this.ShouldSerializeLinkIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLogValue { get; set; } = true;

                public bool ShouldSerializeLog()
                {
                        return this.ShouldSerializeLogValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDateEnteredValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLinkIdValue = false;
                        this.ShouldSerializeLogValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a52dc7cc52ad436b4451154acfcb990a</Hash>
</Codenesium>*/