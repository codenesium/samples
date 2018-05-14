using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiFamilyModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFamilyModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>93b0fdddd3f9d8a9fb03c5101363acff</Hash>
</Codenesium>*/