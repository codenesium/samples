using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesOrderHeaderSalesReasonRequestModelValidator : AbstractApiSalesOrderHeaderSalesReasonRequestModelValidator, IApiSalesOrderHeaderSalesReasonRequestModelValidator
        {
                public ApiSalesOrderHeaderSalesReasonRequestModelValidator(ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository)
                        : base(salesOrderHeaderSalesReasonRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderSalesReasonRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.SalesReasonIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.SalesReasonIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>abbf88ab857dd9adf8db26c8d90ee8d4</Hash>
</Codenesium>*/