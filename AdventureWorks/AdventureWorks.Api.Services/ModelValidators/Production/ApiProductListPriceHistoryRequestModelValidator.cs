using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductListPriceHistoryRequestModelValidator: AbstractApiProductListPriceHistoryRequestModelValidator, IApiProductListPriceHistoryRequestModelValidator
        {
                public ApiProductListPriceHistoryRequestModelValidator(IProductListPriceHistoryRepository productListPriceHistoryRepository)
                        : base(productListPriceHistoryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductListPriceHistoryRequestModel model)
                {
                        this.EndDateRules();
                        this.ListPriceRules();
                        this.ModifiedDateRules();
                        this.StartDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductListPriceHistoryRequestModel model)
                {
                        this.EndDateRules();
                        this.ListPriceRules();
                        this.ModifiedDateRules();
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
    <Hash>0566566b98ebb3ebe45a0f54df42f4cd</Hash>
</Codenesium>*/