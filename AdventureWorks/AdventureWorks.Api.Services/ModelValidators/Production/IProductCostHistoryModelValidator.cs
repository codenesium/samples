using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductCostHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>330bb559f1e693fe917c8221c68977a2</Hash>
</Codenesium>*/