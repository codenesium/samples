using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonStatusModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LessonStatusModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LessonStatusModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>629e4f2d53c024e85a3336bec93767fc</Hash>
</Codenesium>*/