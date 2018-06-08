using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>c54a96a064d947761398f9ea90f2665b</Hash>
</Codenesium>*/