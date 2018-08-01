using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiStudentXFamilyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>98bcd31f30a06589d5ff878969f62406</Hash>
</Codenesium>*/