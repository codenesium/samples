using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IApiChainRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiChainRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>92b7f5f10d7bbc4804a75f6a76903185</Hash>
</Codenesium>*/