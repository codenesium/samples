using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IApiVersionInfoModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoModel model);
		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoModel model);
		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>a96a1253fac1fd407c7e1ec74995122d</Hash>
</Codenesium>*/