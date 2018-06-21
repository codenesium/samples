using Codenesium.DataConversionExtensions;
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

                public void SetProperties(
                        Nullable<DateTime> appliedOn,
                        string description)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                }

                private Nullable<DateTime> appliedOn;

                public Nullable<DateTime> AppliedOn
                {
                        get
                        {
                                return this.appliedOn.IsEmptyOrZeroOrNull() ? null : this.appliedOn;
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
                                return this.description.IsEmptyOrZeroOrNull() ? null : this.description;
                        }

                        set
                        {
                                this.description = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c8fee6f9d661b9fd2e0cc3b94e44b7de</Hash>
</Codenesium>*/