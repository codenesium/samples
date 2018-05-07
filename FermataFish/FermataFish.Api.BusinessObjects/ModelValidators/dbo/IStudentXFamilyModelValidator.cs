using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStudentXFamilyModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(StudentXFamilyModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, StudentXFamilyModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b278d95cfbf50f996b661b2d566e707e</Hash>
</Codenesium>*/