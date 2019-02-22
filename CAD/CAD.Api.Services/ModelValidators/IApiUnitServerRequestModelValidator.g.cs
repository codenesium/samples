using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiUnitServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUnitServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a9fd137e3a852dda9a4313cc1bb71fa6</Hash>
</Codenesium>*/