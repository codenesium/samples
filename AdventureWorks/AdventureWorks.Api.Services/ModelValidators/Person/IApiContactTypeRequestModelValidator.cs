using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiContactTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c9b3a4346f6461bbe79c22ac4281bd7d</Hash>
</Codenesium>*/