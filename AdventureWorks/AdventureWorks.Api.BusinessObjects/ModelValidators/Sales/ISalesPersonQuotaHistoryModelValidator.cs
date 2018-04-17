using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesPersonQuotaHistoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesPersonQuotaHistoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesPersonQuotaHistoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f13cb0ddf9de97b1891f6e2b2210ac3f</Hash>
</Codenesium>*/