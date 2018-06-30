using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiVersionInfoRequestModel : AbstractApiRequestModel
        {
                public ApiVersionInfoRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime? appliedOn,
                        string description)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                }

                private DateTime? appliedOn;

                public DateTime? AppliedOn
                {
                        get
                        {
                                return this.appliedOn;
                        }

                        set
                        {
                                this.appliedOn = value;
                        }
                }

                private string description;

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
        }
}

/*<Codenesium>
    <Hash>6d4288d9bdaf5dd9f088ac937d663ae7</Hash>
</Codenesium>*/