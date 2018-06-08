using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>d7753ea67435f1076776c6b4dda12b5c</Hash>
</Codenesium>*/