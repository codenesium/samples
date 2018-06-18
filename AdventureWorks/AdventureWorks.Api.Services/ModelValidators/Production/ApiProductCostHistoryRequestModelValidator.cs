using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductCostHistoryRequestModelValidator: AbstractApiProductCostHistoryRequestModelValidator, IApiProductCostHistoryRequestModelValidator
        {
                public ApiProductCostHistoryRequestModelValidator(IProductCostHistoryRepository productCostHistoryRepository)
                        : base(productCostHistoryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryRequestModel model)
                {
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.StandardCostRules();
                        this.StartDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryRequestModel model)
                {
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.StandardCostRules();
                        this.StartDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>473c85e3a2861f2c84b5c847680b6a3a</Hash>
</Codenesium>*/