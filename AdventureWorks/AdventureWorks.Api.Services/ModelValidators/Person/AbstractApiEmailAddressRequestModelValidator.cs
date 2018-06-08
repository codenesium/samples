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
        public abstract class AbstractApiEmailAddressRequestModelValidator: AbstractValidator<ApiEmailAddressRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiEmailAddressRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiEmailAddressRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void EmailAddress1Rules()
                {
                        this.RuleFor(x => x.EmailAddress1).Length(0, 50);
                }

                public virtual void EmailAddressIDRules()
                {
                        this.RuleFor(x => x.EmailAddressID).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>30f698e1f091e6478c0e40743870b980</Hash>
</Codenesium>*/