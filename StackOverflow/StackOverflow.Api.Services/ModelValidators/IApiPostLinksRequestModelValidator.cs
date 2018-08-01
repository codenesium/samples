using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiPostLinksRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostLinksRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinksRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d0943dde43c5aaba32bdaab005964d88</Hash>
</Codenesium>*/