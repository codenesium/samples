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
        public abstract class AbstractApiSalesReasonRequestModelValidator: AbstractValidator<ApiSalesReasonRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSalesReasonRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesReasonRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void ReasonTypeRules()
                {
                        this.RuleFor(x => x.ReasonType).NotNull();
                        this.RuleFor(x => x.ReasonType).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>554c43885abc12380094f4db1ae67c80</Hash>
</Codenesium>*/