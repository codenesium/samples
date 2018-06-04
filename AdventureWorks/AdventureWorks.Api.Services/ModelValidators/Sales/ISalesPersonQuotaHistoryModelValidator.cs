using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>0cb82a6fc6b59df80b210a6316458b58</Hash>
</Codenesium>*/