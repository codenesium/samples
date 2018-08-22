using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostLinksRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostLinksRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinksRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fd93dab9ecb058a952ff519d2b70cdc1</Hash>
</Codenesium>*/