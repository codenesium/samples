using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCultureRequestModelValidator : AbstractApiCultureRequestModelValidator, IApiCultureRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>c4fe2cef5595b17199697d2099618d53</Hash>
</Codenesium>*/