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
    <Hash>0b21a167114fc95ac3d352e36cf08e44</Hash>
</Codenesium>*/