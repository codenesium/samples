using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShiftServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShiftServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a29520f980984598b5027a54e5067729</Hash>
</Codenesium>*/