using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiVersionInfoModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoModel model);
		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoModel model);
		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>65b65d11caca637c449f6d0d790565bd</Hash>
</Codenesium>*/