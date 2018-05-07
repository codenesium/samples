using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IFamilyModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(FamilyModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, FamilyModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cf3b929c14260f202081a4f5dfeed88c</Hash>
</Codenesium>*/