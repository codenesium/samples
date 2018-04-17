using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IScrapReasonModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ScrapReasonModel model);
		Task<ValidationResult>  ValidateUpdateAsync(short id, ScrapReasonModel model);
		Task<ValidationResult>  ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>23dc4701e09ca2595c43bf4980d30182</Hash>
</Codenesium>*/