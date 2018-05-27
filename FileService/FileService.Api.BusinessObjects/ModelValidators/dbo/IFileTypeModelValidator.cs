using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IApiFileTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>792bfa1f62fb7c156edad822c4ace0b6</Hash>
</Codenesium>*/