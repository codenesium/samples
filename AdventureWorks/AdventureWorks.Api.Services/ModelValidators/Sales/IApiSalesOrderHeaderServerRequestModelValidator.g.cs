using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesOrderHeaderServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cd0385579a747e98c19bf54849de80ae</Hash>
</Codenesium>*/