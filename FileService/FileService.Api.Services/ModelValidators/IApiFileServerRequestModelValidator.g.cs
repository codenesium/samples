using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiFileServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0834e5a6bb7d9624725308351f2ba582</Hash>
</Codenesium>*/