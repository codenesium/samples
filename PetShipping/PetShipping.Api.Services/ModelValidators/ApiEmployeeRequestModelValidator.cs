using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiEmployeeRequestModelValidator: AbstractApiEmployeeRequestModelValidator, IApiEmployeeRequestModelValidator
        {
                public ApiEmployeeRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model)
                {
                        this.FirstNameRules();
                        this.IsSalesPersonRules();
                        this.IsShipperRules();
                        this.LastNameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model)
                {
                        this.FirstNameRules();
                        this.IsSalesPersonRules();
                        this.IsShipperRules();
                        this.LastNameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>6f433dfa6d58801964d0a7366cb3c3b5</Hash>
</Codenesium>*/