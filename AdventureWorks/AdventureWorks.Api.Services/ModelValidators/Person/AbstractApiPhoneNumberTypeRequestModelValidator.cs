using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiPhoneNumberTypeRequestModelValidator : AbstractValidator<ApiPhoneNumberTypeRequestModel>
        {
                private int existingRecordId;

                private IPhoneNumberTypeRepository phoneNumberTypeRepository;

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
    <Hash>63289ed28ab8d03aa30a9f4247e89455</Hash>
</Codenesium>*/