using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiBusinessEntityRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c8c4d2b85327b75fbdfb6561f12cdf20</Hash>
</Codenesium>*/