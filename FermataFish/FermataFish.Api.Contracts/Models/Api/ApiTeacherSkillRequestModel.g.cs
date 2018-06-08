using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiTeacherSkillRequestModel: AbstractApiRequestModel
        {
                public ApiTeacherSkillRequestModel() : base()
                {
                }

                public void SetProperties(
                        string name,
                        int studioId)
                {
                        this.Name = name;
                        this.StudioId = studioId;
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private int studioId;

                [Required]
                public int StudioId
                {
                        get
                        {
                                return this.studioId;
                        }

                        set
                        {
                                this.studioId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b06bacb79f004c236b41874f302318dd</Hash>
</Codenesium>*/