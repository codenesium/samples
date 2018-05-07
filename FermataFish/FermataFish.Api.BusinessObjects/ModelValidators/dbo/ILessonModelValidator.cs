using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(LessonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, LessonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a123c2d17cd9e54db47d4e274d91bcba</Hash>
</Codenesium>*/