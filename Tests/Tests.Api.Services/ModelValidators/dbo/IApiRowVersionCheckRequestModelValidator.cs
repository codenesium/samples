using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public interface IApiRowVersionCheckRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRowVersionCheckRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRowVersionCheckRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3da5f5b2562718ef7671aa72c47cfedb</Hash>
</Codenesium>*/