using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiProjectRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProjectRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>f08df71b735c8cf7f61540a5adfdec15</Hash>
</Codenesium>*/