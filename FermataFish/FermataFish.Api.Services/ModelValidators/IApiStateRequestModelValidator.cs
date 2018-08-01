using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiStateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5d6f3fec1d5d03348d4387a5eb65969f</Hash>
</Codenesium>*/