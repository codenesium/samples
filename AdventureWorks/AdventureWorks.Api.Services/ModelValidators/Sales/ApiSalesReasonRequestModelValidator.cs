using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesReasonRequestModelValidator: AbstractApiSalesReasonRequestModelValidator, IApiSalesReasonRequestModelValidator
        {
                public ApiSalesReasonRequestModelValidator(ISalesReasonRepository salesReasonRepository)
                        : base(salesReasonRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.ReasonTypeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.ReasonTypeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>2bfa542a4594801f3dc822833ec10dde</Hash>
</Codenesium>*/