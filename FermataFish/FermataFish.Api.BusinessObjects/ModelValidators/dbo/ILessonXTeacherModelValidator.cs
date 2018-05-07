using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonXTeacherModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(LessonXTeacherModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, LessonXTeacherModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6d354888fe6712f1a9ceacde62a740af</Hash>
</Codenesium>*/