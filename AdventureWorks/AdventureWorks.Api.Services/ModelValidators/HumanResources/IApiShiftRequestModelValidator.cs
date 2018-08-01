using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiShiftRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShiftRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3d6bf7b1a16d61c326b286ed74e4871d</Hash>
</Codenesium>*/