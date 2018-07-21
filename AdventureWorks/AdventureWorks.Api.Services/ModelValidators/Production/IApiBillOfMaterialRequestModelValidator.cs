using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiBillOfMaterialRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>5b2e429c2864929f2a9696ada544f2bd</Hash>
</Codenesium>*/