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
    <Hash>1a3c2cedd22e89548f3d27fefb2e57c6</Hash>
</Codenesium>*/