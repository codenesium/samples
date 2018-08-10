using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesPersonQuotaHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonQuotaHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>13e26b36aa789d316b615b265dbb44d5</Hash>
</Codenesium>*/