using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiStoreRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiStoreRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>07aa8f7811fd298f7da7d9f144c4ee4e</Hash>
</Codenesium>*/