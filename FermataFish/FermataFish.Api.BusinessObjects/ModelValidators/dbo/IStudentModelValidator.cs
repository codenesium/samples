using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiStudentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2f884710e0a5a86f04613783233fad48</Hash>
</Codenesium>*/