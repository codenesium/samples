using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStudentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(StudentModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, StudentModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d28a7fa27f484b0bea62b6491cd41252</Hash>
</Codenesium>*/