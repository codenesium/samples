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
        public abstract class AbstractApiJobCandidateRequestModelValidator: AbstractValidator<ApiJobCandidateRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiJobCandidateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiJobCandidateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void BusinessEntityIDRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void ResumeRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>bf50b7eeb745bfcc158bde5a050a3b50</Hash>
</Codenesium>*/