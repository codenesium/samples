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
    <Hash>36aa0c4a2f037f62339063b211fd40e9</Hash>
</Codenesium>*/