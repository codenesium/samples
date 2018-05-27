using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIllustrationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3ad0d5a76dd1d96b5a059fbd6c549688</Hash>
</Codenesium>*/