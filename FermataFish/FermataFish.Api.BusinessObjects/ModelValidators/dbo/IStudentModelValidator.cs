using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStudentModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StudentModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StudentModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9842c9d15bf38c654b48c79b13415b60</Hash>
</Codenesium>*/