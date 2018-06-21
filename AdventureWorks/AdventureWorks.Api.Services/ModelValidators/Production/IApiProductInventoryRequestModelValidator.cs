using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductInventoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductInventoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductInventoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a070e2dab5f4035cba918cc31b9688c7</Hash>
</Codenesium>*/