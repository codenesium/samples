using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiFamilyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5d17c9d97dddec803c1ee3ef465bc2b0</Hash>
</Codenesium>*/