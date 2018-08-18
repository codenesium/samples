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
    <Hash>75f9dda58dd3ce951bec077af68883bd</Hash>
</Codenesium>*/