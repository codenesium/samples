using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractApiVersionInfoRequestModelValidator: AbstractValidator<ApiVersionInfoRequestModel>
        {
                private long existingRecordId;

                IVersionInfoRepository versionInfoRepository;

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
    <Hash>186995574edb1665d6734b6082cd6811</Hash>
</Codenesium>*/