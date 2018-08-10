using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductDescriptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>699137c1708d4335062f55be23d6ed9f</Hash>
</Codenesium>*/