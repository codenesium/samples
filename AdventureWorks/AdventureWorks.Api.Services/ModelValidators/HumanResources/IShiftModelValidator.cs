using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>92f0f1c991297b62f60ca1a267f48fd6</Hash>
</Codenesium>*/