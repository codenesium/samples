using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.Services
{
        public interface IApiSaleRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>dd655463e5ebcd79443a69f468347d1d</Hash>
</Codenesium>*/