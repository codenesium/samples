using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiBillOfMaterialRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cb31cfb252ed12e87c083584acfcbb90</Hash>
</Codenesium>*/