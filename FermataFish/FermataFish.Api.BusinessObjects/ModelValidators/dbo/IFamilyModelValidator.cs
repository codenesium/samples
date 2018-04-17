using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IFamilyModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(FamilyModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, FamilyModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24aaa9912f3e44c00acd7474dd18bc86</Hash>
</Codenesium>*/