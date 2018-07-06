using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiLinkLogResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime dateEntered,
                        int linkId,
                        string log)
                {
                        this.Id = id;
                        this.DateEntered = dateEntered;
                        this.LinkId = linkId;
                        this.Log = log;

                        this.LinkIdEntity = nameof(ApiResponse.Links);
                }

                public DateTime DateEntered { get; private set; }

                public int Id { get; private set; }

                public int LinkId { get; private set; }

                public string LinkIdEntity { get; set; }

                public string Log { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4821cecafdcfaff7a12226a632d590ba</Hash>
</Codenesium>*/