using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f43f2d27afe5eee8bb979a4521bf3695</Hash>
</Codenesium>*/