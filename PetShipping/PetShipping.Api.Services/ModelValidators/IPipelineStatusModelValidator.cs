using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineStatusRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>85771f1c043f7fcfeb4178fbacd221c5</Hash>
</Codenesium>*/