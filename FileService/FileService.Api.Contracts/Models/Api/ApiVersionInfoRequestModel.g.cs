using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
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
    <Hash>8455e5d35a42a4f3106b0d41be0576aa</Hash>
</Codenesium>*/