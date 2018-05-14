using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiScrapReasonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>de266fcfc91ba8674737956a6f6d8160</Hash>
</Codenesium>*/