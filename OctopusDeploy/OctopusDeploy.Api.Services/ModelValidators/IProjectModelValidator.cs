using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>5d198ff765d0f71fc3b90733237783cd</Hash>
</Codenesium>*/