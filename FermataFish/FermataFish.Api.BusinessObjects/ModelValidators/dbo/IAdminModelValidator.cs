using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IAdminModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(AdminModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, AdminModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>65bb6571bcff48d48c8e3df06e0b5343</Hash>
</Codenesium>*/