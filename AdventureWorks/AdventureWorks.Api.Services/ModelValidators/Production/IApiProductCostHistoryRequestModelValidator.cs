using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>29598dd54dbc2c93dd73d954c57dd97c</Hash>
</Codenesium>*/