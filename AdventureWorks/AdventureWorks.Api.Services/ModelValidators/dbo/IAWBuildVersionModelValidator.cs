using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiAWBuildVersionRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>5407fe821b11f89f2494f3b0aa75327d</Hash>
</Codenesium>*/