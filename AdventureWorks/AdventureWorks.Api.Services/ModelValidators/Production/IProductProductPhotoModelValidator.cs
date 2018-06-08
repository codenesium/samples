using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>1d69975b6003ebd65c8526a87d16b91e</Hash>
</Codenesium>*/