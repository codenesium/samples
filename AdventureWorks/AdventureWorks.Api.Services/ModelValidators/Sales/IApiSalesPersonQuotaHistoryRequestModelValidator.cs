using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesPersonQuotaHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonQuotaHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f6bc540a0b1151e013563ef297ce2b3e</Hash>
</Codenesium>*/