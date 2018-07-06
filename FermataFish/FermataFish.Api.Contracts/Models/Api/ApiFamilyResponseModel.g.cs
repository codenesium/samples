using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiFamilyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string notes,
                        string pcEmail,
                        string pcFirstName,
                        string pcLastName,
                        string pcPhone,
                        int studioId)
                {
                        this.Id = id;
                        this.Notes = notes;
                        this.PcEmail = pcEmail;
                        this.PcFirstName = pcFirstName;
                        this.PcLastName = pcLastName;
                        this.PcPhone = pcPhone;
                        this.StudioId = studioId;

                        this.IdEntity = nameof(ApiResponse.Studios);
                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public int Id { get; private set; }

                public string IdEntity { get; set; }

                public string Notes { get; private set; }

                public string PcEmail { get; private set; }

                public string PcFirstName { get; private set; }

                public string PcLastName { get; private set; }

                public string PcPhone { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>6087ef2bfb2b0e3ce1e2dec4de86575b</Hash>
</Codenesium>*/