using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiStudentXFamilyModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0251ee99ffcd80fdb7503e5afa55c511</Hash>
</Codenesium>*/