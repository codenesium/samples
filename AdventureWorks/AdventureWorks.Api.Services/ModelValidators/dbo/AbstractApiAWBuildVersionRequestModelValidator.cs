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

                IAWBuildVersionRepository aWBuildVersionRepository;

                public AbstractApiAWBuildVersionRequestModelValidator(IAWBuildVersionRepository aWBuildVersionRepository)
                {
                        this.aWBuildVersionRepository = aWBuildVersionRepository;
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
                }

                public virtual void VersionDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>22a1ae2ecb8c99136823c1f3abaf46d5</Hash>
</Codenesium>*/