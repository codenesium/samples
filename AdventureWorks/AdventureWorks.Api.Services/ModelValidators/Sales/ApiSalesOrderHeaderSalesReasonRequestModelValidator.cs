using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesOrderHeaderSalesReasonRequestModelValidator: AbstractApiSalesOrderHeaderSalesReasonRequestModelValidator, IApiSalesOrderHeaderSalesReasonRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>1edef14c313a26d9eeea3259b12ba407</Hash>
</Codenesium>*/