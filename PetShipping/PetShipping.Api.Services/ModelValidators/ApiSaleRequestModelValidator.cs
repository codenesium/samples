using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public class ApiSaleRequestModelValidator : AbstractApiSaleRequestModelValidator, IApiSaleRequestModelValidator
        {
                public ApiSaleRequestModelValidator(ISaleRepository saleRepository)
                        : base(saleRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model)
                {
                        this.AmountRules();
                        this.ClientIdRules();
                        this.NoteRules();
                        this.PetIdRules();
                        this.SaleDateRules();
                        this.SalesPersonIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model)
                {
                        this.AmountRules();
                        this.ClientIdRules();
                        this.NoteRules();
                        this.PetIdRules();
                        this.SaleDateRules();
                        this.SalesPersonIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>ed0449d5cf355efe899bcacc3195ef07</Hash>
</Codenesium>*/