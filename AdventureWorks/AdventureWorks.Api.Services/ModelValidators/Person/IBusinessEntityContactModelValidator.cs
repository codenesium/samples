using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiBusinessEntityContactRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>db73c1c303233741deef9bf27ce2d8a7</Hash>
</Codenesium>*/