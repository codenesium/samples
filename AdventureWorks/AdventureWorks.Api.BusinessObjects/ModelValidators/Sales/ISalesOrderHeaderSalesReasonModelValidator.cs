using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesOrderHeaderSalesReasonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderSalesReasonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b5efddfad8736855403c6fefa2ff985d</Hash>
</Codenesium>*/