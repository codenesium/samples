using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
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
    <Hash>63e8d71eb3ecbc7c1fd1706c6602790e</Hash>
</Codenesium>*/