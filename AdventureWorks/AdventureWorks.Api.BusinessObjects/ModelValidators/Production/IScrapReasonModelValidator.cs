using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IScrapReasonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ScrapReasonModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ScrapReasonModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>b80f05a9cb4f48f2c3ba4cb2a059f85e</Hash>
</Codenesium>*/