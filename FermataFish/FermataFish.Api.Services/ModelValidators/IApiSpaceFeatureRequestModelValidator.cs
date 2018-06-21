using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiSpaceFeatureRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>da95406a3d9769cf3972a4c873b14ab1</Hash>
</Codenesium>*/