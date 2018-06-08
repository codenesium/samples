using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiPersonPhoneRequestModelValidator: AbstractApiPersonPhoneRequestModelValidator, IApiPersonPhoneRequestModelValidator
        {
                public ApiPersonPhoneRequestModelValidator()
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
    <Hash>46b3b0263f87aff69e0be4cd7c39e1f8</Hash>
</Codenesium>*/