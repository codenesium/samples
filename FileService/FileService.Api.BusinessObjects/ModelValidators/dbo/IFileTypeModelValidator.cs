using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IApiFileTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>019e8f2bbb163fdd0eca8b4093a8b2e6</Hash>
</Codenesium>*/