using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesOrderHeaderSalesReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderSalesReasonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2e08d951c0e07f0d017b6029c3765ceb</Hash>
</Codenesium>*/