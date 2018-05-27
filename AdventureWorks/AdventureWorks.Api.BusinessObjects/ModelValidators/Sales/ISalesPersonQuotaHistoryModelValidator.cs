using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesPersonQuotaHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonQuotaHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>74f7d870999c96ca0053049161c6fdd8</Hash>
</Codenesium>*/