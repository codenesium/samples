using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesOrderDetailRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b6f3b7d7ec1da78e1e38a9000a866bb4</Hash>
</Codenesium>*/