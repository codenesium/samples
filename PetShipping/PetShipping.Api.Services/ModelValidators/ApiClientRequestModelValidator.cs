using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiClientRequestModelValidator: AbstractApiClientRequestModelValidator, IApiClientRequestModelValidator
        {
                public ApiClientRequestModelValidator(IClientRepository clientRepository)
                        : base(clientRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiClientRequestModel model)
                {
                        this.EmailRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.NotesRules();
                        this.PhoneRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientRequestModel model)
                {
                        this.EmailRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.NotesRules();
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
    <Hash>a2c6419f4d2e39565c4a14888a589cce</Hash>
</Codenesium>*/