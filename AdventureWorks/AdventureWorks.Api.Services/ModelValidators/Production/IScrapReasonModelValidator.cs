using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiScrapReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>13995ad1fecf7c1510049ba137191002</Hash>
</Codenesium>*/