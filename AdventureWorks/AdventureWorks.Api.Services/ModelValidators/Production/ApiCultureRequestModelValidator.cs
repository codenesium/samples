using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCultureRequestModelValidator: AbstractApiCultureRequestModelValidator, IApiCultureRequestModelValidator
        {
                public ApiCultureRequestModelValidator(ICultureRepository cultureRepository)
                        : base(cultureRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCultureRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>fcd8e7c70b60ea670c62933895bfe8b3</Hash>
</Codenesium>*/