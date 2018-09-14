using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.Services
{
    public partial interface IApiFileRequestModelValidator 
    {
		 Task<ValidationResult> ValidateCreateAsync(ApiFileRequestModel model);

		 Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileRequestModel model);
		 
		 Task<ValidationResult> ValidateDeleteAsync(int id);
    }
}

/*<Codenesium>
    <Hash>5e7d5916b4cd8842a0d5598a39ecaaa8</Hash>
</Codenesium>*/