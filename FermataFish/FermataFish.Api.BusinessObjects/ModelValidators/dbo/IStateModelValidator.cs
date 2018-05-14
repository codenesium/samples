using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiStateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8f98412c064d3c0ef6883181bdc41c71</Hash>
</Codenesium>*/