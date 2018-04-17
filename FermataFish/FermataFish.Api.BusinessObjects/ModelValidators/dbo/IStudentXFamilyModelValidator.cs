using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStudentXFamilyModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StudentXFamilyModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StudentXFamilyModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8731535cf3dab6ec1cf16b7624ee6dde</Hash>
</Codenesium>*/