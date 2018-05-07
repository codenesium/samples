using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStudioModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(StudioModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, StudioModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>840961b93c0fc3273017403a650e0f9d</Hash>
</Codenesium>*/