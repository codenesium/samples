using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductProductPhotoRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>baa7581906667ff4e22d61cd917e505e</Hash>
</Codenesium>*/