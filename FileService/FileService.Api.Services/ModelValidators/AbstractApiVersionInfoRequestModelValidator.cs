using Codenesium.DataConversionExtensions.AspNetCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
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
    <Hash>62889e536f31628666cd10e4e07a923f</Hash>
</Codenesium>*/