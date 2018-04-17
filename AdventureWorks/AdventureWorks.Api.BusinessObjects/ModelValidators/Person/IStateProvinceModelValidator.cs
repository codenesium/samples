using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IStateProvinceModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StateProvinceModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StateProvinceModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>94a1b16dbe6b9b7a6bc79c7c903795b7</Hash>
</Codenesium>*/