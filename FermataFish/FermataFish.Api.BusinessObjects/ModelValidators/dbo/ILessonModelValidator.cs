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
    <Hash>f47d82fbbd9c3a718dc6597d6f681e9c</Hash>
</Codenesium>*/