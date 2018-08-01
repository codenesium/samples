using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>12f9266f79c6702b67de7b01caca39fc</Hash>
</Codenesium>*/