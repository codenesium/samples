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
    <Hash>96016ab59a83f35d81cb53ad1577b6b2</Hash>
</Codenesium>*/