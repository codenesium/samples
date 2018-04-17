using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LessonModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LessonModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a5736875c8251e48b2789db5aa723a14</Hash>
</Codenesium>*/