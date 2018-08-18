using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShiftRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShiftRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ad185ef36fe1c8f035556a6b080dc663</Hash>
</Codenesium>*/