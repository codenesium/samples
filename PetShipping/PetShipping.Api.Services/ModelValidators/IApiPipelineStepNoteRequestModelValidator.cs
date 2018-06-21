using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>77e32a8621ba0c935699cfd98db0f514</Hash>
</Codenesium>*/