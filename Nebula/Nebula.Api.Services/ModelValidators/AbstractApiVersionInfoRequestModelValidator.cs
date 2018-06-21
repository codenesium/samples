using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractApiVersionInfoRequestModelValidator : AbstractValidator<ApiVersionInfoRequestModel>
        {
                private long existingRecordId;

                private IVersionInfoRepository versionInfoRepository;

                public AbstractApiVersionInfoRequestModelValidator(IVersionInfoRepository versionInfoRepository)
                {
                        this.versionInfoRepository = versionInfoRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiVersionInfoRequestModel model, long id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AppliedOnRules()
                {
                }

                public virtual void DescriptionRules()
                {
                        this.RuleFor(x => x.Description).Length(0, 1024);
                }
        }
}

/*<Codenesium>
    <Hash>893fa48a086c85286ba8514b1cdaa010</Hash>
</Codenesium>*/