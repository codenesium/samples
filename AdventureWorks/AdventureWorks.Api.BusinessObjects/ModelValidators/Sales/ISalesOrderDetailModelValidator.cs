using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesOrderDetailModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesOrderDetailModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderDetailModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd618aaba8db28cb2e46630cdcaecaca</Hash>
</Codenesium>*/