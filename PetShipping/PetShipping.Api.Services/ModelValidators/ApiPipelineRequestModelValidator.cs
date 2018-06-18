using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineRequestModelValidator: AbstractApiPipelineRequestModelValidator, IApiPipelineRequestModelValidator
        {
                public ApiPipelineRequestModelValidator(IPipelineRepository pipelineRepository)
                        : base(pipelineRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineRequestModel model)
                {
                        this.PipelineStatusIdRules();
                        this.SaleIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineRequestModel model)
                {
                        this.PipelineStatusIdRules();
                        this.SaleIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>239b8726b2bf806dad65caf70b2893ce</Hash>
</Codenesium>*/