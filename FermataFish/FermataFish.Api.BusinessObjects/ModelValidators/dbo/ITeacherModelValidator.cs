using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ITeacherModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(TeacherModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, TeacherModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>73bb5dd4311cdc4539432f1371e6e37c</Hash>
</Codenesium>*/