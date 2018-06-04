using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
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
    <Hash>d3e90f51dfaabebfba37f6e41de1f48b</Hash>
</Codenesium>*/