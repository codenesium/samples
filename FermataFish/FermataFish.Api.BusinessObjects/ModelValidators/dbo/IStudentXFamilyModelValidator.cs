using System;
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
    <Hash>593a232d4c49de03e72013c38284efd6</Hash>
</Codenesium>*/