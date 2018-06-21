using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public interface IApiFileRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiFileRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>cbbbdf38f21aca35465e2fa9644457fc</Hash>
</Codenesium>*/