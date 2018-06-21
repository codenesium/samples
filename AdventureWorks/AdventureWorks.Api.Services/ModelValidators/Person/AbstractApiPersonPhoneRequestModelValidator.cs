using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiPersonPhoneRequestModelValidator : AbstractValidator<ApiPersonPhoneRequestModel>
        {
                private int existingRecordId;

                private IPersonPhoneRepository personPhoneRepository;

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
    <Hash>6c17220853b173546be9ae6b9d6d4cdb</Hash>
</Codenesium>*/