using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineStepNoteRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>b7e1121e66ea255557a8bcd0db37e9f4</Hash>
</Codenesium>*/