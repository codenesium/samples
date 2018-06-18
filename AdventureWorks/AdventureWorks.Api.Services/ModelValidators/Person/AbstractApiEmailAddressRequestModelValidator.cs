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

                IEmailAddressRepository emailAddressRepository;

                public AbstractApiEmailAddressRequestModelValidator(IEmailAddressRepository emailAddressRepository)
                {
                        this.emailAddressRepository = emailAddressRepository;
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
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void RowguidRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a702aaadcbb66419f7567c8b3f6be2dd</Hash>
</Codenesium>*/