using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiStoreRequestModelValidator : AbstractApiStoreRequestModelValidator, IApiStoreRequestModelValidator
        {
                public ApiStoreRequestModelValidator(IStoreRepository storeRepository)
                        : base(storeRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>c38c5f009e89a23d9d8b37445c783903</Hash>
</Codenesium>*/