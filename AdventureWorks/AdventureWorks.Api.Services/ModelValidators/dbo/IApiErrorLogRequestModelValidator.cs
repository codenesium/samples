using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiErrorLogRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2bd002bf4e78daf59ee2fb28ccb09301</Hash>
</Codenesium>*/