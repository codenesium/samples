using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IApiFileModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cd07d656daf148abc843290cce78ef27</Hash>
</Codenesium>*/