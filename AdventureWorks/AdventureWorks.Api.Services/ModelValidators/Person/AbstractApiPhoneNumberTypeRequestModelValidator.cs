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
        public abstract class AbstractApiPhoneNumberTypeRequestModelValidator: AbstractValidator<ApiPhoneNumberTypeRequestModel>
        {
                private int existingRecordId;

                IPhoneNumberTypeRepository phoneNumberTypeRepository;

                public AbstractApiPhoneNumberTypeRequestModelValidator(IPhoneNumberTypeRepository phoneNumberTypeRepository)
                {
                        this.phoneNumberTypeRepository = phoneNumberTypeRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPhoneNumberTypeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>01d7cbc7823303cc01300f555bb7487a</Hash>
</Codenesium>*/