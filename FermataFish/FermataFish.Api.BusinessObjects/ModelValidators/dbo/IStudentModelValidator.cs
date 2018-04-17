using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStudentModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StudentModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StudentModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>89760c2a0e0d880be2fa39a0169e50e4</Hash>
</Codenesium>*/