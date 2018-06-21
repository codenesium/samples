using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiPostTypesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPostTypesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>dba19098f9e829936e5a082129148dd2</Hash>
</Codenesium>*/