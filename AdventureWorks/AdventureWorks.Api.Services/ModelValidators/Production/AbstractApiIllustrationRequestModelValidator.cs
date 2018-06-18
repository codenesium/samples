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
        public abstract class AbstractApiIllustrationRequestModelValidator: AbstractValidator<ApiIllustrationRequestModel>
        {
                private int existingRecordId;

                IIllustrationRepository illustrationRepository;

                public AbstractApiIllustrationRequestModelValidator(IIllustrationRepository illustrationRepository)
                {
                        this.illustrationRepository = illustrationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiIllustrationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DiagramRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d0f84780f430f13d790282f5445d015f</Hash>
</Codenesium>*/