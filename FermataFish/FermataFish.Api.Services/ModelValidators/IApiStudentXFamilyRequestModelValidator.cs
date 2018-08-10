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
    <Hash>1d7a24e014a67666fe0d7b55521b2cc2</Hash>
</Codenesium>*/