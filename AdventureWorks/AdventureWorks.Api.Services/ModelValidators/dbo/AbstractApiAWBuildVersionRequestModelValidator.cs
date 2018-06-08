using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services

{
        public abstract class AbstractApiAWBuildVersionRequestModelValidator: AbstractValidator<ApiAWBuildVersionRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiAWBuildVersionRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiAWBuildVersionRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void Database_VersionRules()
                {
                        this.RuleFor(x => x.Database_Version).NotNull();
                        this.RuleFor(x => x.Database_Version).Length(0, 25);
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void VersionDateRules()
                {
                        this.RuleFor(x => x.VersionDate).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>b0f73c83d03290c2d5aa123bcc3ecacc</Hash>
</Codenesium>*/