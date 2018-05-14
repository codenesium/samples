using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductReviewModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductReviewModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e658243aec5252b65a1f92597334b57d</Hash>
</Codenesium>*/