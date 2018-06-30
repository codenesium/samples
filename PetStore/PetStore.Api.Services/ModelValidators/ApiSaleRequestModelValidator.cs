using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>91717fd7ab5113485daa75163d4e4c3e</Hash>
</Codenesium>*/