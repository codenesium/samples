using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IApiVersionInfoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>6977b2bd5f16fdfc079fdce4e95e8bb6</Hash>
</Codenesium>*/