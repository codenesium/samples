using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(LessonStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, LessonStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0005445779130f3221ac61110bc3d5ca</Hash>
</Codenesium>*/