using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesOrderHeaderSalesReasonModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesOrderHeaderSalesReasonModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesOrderHeaderSalesReasonModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>897569e45761363dc45d3673cd2f0021</Hash>
</Codenesium>*/