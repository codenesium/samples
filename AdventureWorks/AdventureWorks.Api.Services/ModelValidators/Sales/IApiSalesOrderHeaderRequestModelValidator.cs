using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesOrderHeaderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>84cb925567ad68a926a2fb38033ce35f</Hash>
</Codenesium>*/