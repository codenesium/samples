using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IStateProvinceModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(StateProvinceModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, StateProvinceModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>77215f3a433ba1ea9323d42338b635f2</Hash>
</Codenesium>*/