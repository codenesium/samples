using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesPersonQuotaHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonQuotaHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonQuotaHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>849ab51f29010af0a2770517dacdb3ae</Hash>
</Codenesium>*/