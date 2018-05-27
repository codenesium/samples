using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiScrapReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>87127fad4f20df04ff137e0ec5cda360</Hash>
</Codenesium>*/