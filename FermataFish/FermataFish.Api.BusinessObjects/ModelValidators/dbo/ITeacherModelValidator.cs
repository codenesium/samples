using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ITeacherModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(TeacherModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, TeacherModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4459eaa55365b66776287e43f01a04bf</Hash>
</Codenesium>*/