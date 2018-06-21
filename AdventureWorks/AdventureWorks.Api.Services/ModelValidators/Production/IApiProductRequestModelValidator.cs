using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>4a8b567d1b3c78521c38127569c62f95</Hash>
</Codenesium>*/