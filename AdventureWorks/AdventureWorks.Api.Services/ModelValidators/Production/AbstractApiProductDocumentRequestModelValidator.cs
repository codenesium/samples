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
        public abstract class AbstractApiProductDocumentRequestModelValidator: AbstractValidator<ApiProductDocumentRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductDocumentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductDocumentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DocumentNodeRules()
                {
                        this.RuleFor(x => x.DocumentNode).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>11e0ca46e928846d50ae478a8cb6809b</Hash>
</Codenesium>*/