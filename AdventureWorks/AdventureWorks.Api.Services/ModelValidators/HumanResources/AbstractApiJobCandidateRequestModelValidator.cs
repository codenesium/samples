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
                }

                public virtual void ResumeRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7c01d9aef3a5df6fac2c4af19d41efc0</Hash>
</Codenesium>*/