using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRateRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>320cd716f0da88e17a910a48b19cc67d</Hash>
</Codenesium>*/