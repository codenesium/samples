using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiPhoneNumberTypeRequestModelValidator: AbstractApiPhoneNumberTypeRequestModelValidator, IApiPhoneNumberTypeRequestModelValidator
        {
                public ApiPhoneNumberTypeRequestModelValidator(IPhoneNumberTypeRepository phoneNumberTypeRepository)
                        : base(phoneNumberTypeRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>eb211516811ad647dcb45716c957c0f3</Hash>
</Codenesium>*/