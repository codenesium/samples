using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiSpaceFeatureRequestModel : AbstractApiRequestModel
        {
                public ApiSpaceFeatureRequestModel()
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
    <Hash>53dd6c5c757ad07e90056fd3856b7180</Hash>
</Codenesium>*/