using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiFeedRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiFeedRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiFeedRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>60f040138b4045c506c8539bda35938a</Hash>
</Codenesium>*/