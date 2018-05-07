using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IAdminModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(AdminModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, AdminModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ab4e0b75efce402f2dd55dbbac68763e</Hash>
</Codenesium>*/