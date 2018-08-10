using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiFamilyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e8792eee07b776cdc7c2cbc77a2746d8</Hash>
</Codenesium>*/