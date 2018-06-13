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
        public abstract class AbstractApiBusinessEntityContactRequestModelValidator: AbstractValidator<ApiBusinessEntityContactRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiBusinessEntityContactRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityContactRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ContactTypeIDRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void PersonIDRules()
                {
                }

                public virtual void RowguidRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>e18431e5ad0e9652a8a1eefe8148f2e6</Hash>
</Codenesium>*/