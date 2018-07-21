using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiFamilyRequestModel : AbstractApiRequestModel
        {
                public ApiFamilyRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string notes,
                        string pcEmail,
                        string pcFirstName,
                        string pcLastName,
                        string pcPhone,
                        int studioId)
                {
                        this.Notes = notes;
                        this.PcEmail = pcEmail;
                        this.PcFirstName = pcFirstName;
                        this.PcLastName = pcLastName;
                        this.PcPhone = pcPhone;
                        this.StudioId = studioId;
                }

                [JsonProperty]
                public string Notes { get; private set; }

                [JsonProperty]
                public string PcEmail { get; private set; }

                [JsonProperty]
                public string PcFirstName { get; private set; }

                [JsonProperty]
                public string PcLastName { get; private set; }

                [JsonProperty]
                public string PcPhone { get; private set; }

                [JsonProperty]
                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>264f3d14d86ed6188ccd5086aa1ce58e</Hash>
</Codenesium>*/