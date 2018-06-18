using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class ApiSaleRequestModelValidator: AbstractApiSaleRequestModelValidator, IApiSaleRequestModelValidator
        {
                public ApiSaleRequestModelValidator(ISaleRepository saleRepository)
                        : base(saleRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model)
                {
                        this.AmountRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.PaymentTypeIdRules();
                        this.PetIdRules();
                        this.PhoneRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model)
                {
                        this.AmountRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.PaymentTypeIdRules();
                        this.PetIdRules();
                        this.PhoneRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>dac9c64952030e6896c761bf895b2113</Hash>
</Codenesium>*/