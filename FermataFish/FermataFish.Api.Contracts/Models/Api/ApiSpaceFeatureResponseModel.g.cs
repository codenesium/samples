using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiSpaceFeatureResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int studioId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;

                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>c92c7c444e4c5dec2adb00f646ccfe66</Hash>
</Codenesium>*/