using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>a605de106b4e7fa5cd78fc6a36bdb95c</Hash>
</Codenesium>*/