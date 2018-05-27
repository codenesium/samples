using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiWorkOrderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>25131fc174abf557f373cc86b701d4b2</Hash>
</Codenesium>*/