using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiStudentXFamilyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c228a863d2ee5bd5d045229bc9a141a0</Hash>
</Codenesium>*/