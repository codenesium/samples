using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductPhotoRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>4f2cc4716b44651bb36ea4205d79cc0b</Hash>
</Codenesium>*/