using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiDestinationRequestModelValidator: AbstractApiDestinationRequestModelValidator, IApiDestinationRequestModelValidator
        {
                public ApiDestinationRequestModelValidator(IDestinationRepository destinationRepository)
                        : base(destinationRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model)
                {
                        this.CountryIdRules();
                        this.NameRules();
                        this.OrderRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model)
                {
                        this.CountryIdRules();
                        this.NameRules();
                        this.OrderRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>b0e59082a8afa3570199f46e204a2fe4</Hash>
</Codenesium>*/