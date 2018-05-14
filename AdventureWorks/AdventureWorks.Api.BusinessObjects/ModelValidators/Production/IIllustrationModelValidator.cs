using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiIllustrationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIllustrationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>95bf7d07ef6e04c26b3145af7028eaf7</Hash>
</Codenesium>*/