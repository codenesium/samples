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
        public abstract class AbstractApiPersonPhoneRequestModelValidator: AbstractValidator<ApiPersonPhoneRequestModel>
        {
                private int existingRecordId;

                IPersonPhoneRepository personPhoneRepository;

                public AbstractApiPersonPhoneRequestModelValidator(IPersonPhoneRepository personPhoneRepository)
                {
                        this.personPhoneRepository = personPhoneRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPersonPhoneRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void PhoneNumberRules()
                {
                        this.RuleFor(x => x.PhoneNumber).NotNull();
                        this.RuleFor(x => x.PhoneNumber).Length(0, 25);
                }

                public virtual void PhoneNumberTypeIDRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>9b5c4c6fe0080bf5bf428c64f86efd8c</Hash>
</Codenesium>*/