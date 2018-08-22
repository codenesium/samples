using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiStudentXFamilyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ec5628bb14e7d4ff8624edee5b32251d</Hash>
</Codenesium>*/