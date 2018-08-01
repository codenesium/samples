using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public interface IApiPersonRefRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonRefRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRefRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>448800f30c0e5d7e55814fca4b0f9766</Hash>
</Codenesium>*/