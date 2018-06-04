using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
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
    <Hash>846f32fc932cfeec8d16204e268735a3</Hash>
</Codenesium>*/