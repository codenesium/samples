using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiVersionInfoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>c1150e1d5a2cda2fbf5753da7d35ab52</Hash>
</Codenesium>*/