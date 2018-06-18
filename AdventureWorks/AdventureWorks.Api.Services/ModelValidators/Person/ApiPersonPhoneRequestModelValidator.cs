using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiPersonPhoneRequestModelValidator: AbstractApiPersonPhoneRequestModelValidator, IApiPersonPhoneRequestModelValidator
        {
                public ApiPersonPhoneRequestModelValidator(IPersonPhoneRepository personPhoneRepository)
                        : base(personPhoneRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.PhoneNumberRules();
                        this.PhoneNumberTypeIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.PhoneNumberRules();
                        this.PhoneNumberTypeIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>1c8191bcaf6bf16bae61201b3b4c7860</Hash>
</Codenesium>*/