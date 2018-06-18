using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStatusRequestModelValidator: AbstractApiPipelineStatusRequestModelValidator, IApiPipelineStatusRequestModelValidator
        {
                public ApiPipelineStatusRequestModelValidator(IPipelineStatusRepository pipelineStatusRepository)
                        : base(pipelineStatusRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>4b55e7b75abac240a642b531af803a0d</Hash>
</Codenesium>*/