using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductCostHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e767665f3004432c3e09d9890c10a15f</Hash>
</Codenesium>*/