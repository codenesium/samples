using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiTeacherSkillRequestModel : AbstractApiRequestModel
        {
                public ApiTeacherSkillRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name,
                        int studioId)
                {
                        this.Name = name;
                        this.StudioId = studioId;
                }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>fe1cb7bb7c8780126ec48ac919ec7558</Hash>
</Codenesium>*/