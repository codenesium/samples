using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIllustrationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6b907c666dca48064b360636ca3d6537</Hash>
</Codenesium>*/