using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiSpaceRequestModel : AbstractApiRequestModel
        {
                public ApiSpaceRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string description,
                        string name,
                        int studioId)
                {
                        this.Description = description;
                        this.Name = name;
                        this.StudioId = studioId;
                }

                private string description;

                [Required]
                public string Description
                {
                        get
                        {
                                return this.description;
                        }

                        set
                        {
                                this.description = value;
                        }
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
    <Hash>76941c3705c465f47eca6a49b69777fe</Hash>
</Codenesium>*/