using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public interface IApiVersionInfoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>33a092a8b6a4562064df0f75535a0cf9</Hash>
</Codenesium>*/