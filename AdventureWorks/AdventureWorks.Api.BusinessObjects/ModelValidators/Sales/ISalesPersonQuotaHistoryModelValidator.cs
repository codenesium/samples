using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesPersonQuotaHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesPersonQuotaHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesPersonQuotaHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3a0d4ec0a0b52e20ebe1428219816fc6</Hash>
</Codenesium>*/