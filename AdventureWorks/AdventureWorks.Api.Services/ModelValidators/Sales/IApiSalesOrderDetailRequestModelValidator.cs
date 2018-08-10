using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesOrderDetailRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fece4f7d7346b9aca26fdd79f79b53b1</Hash>
</Codenesium>*/