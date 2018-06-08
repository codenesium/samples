using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiBillOfMaterialsRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialsRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialsRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>3a1a3d4adb412cb2f19c37b0cf3d49f0</Hash>
</Codenesium>*/