using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiStoreRequestModelValidator: AbstractApiStoreRequestModelValidator, IApiStoreRequestModelValidator
        {
                public ApiStoreRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiStoreRequestModel model)
                {
                        this.DemographicsRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.SalesPersonIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreRequestModel model)
                {
                        this.DemographicsRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.SalesPersonIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>1b66abe9d82e88af67dc0df9c09392a8</Hash>
</Codenesium>*/