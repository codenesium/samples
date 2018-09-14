using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>cb26713c5fc859eab3ad5170647ada6b</Hash>
</Codenesium>*/