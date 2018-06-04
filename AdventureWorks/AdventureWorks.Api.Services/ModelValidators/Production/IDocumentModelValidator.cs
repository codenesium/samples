using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiDocumentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDocumentRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(Guid id, ApiDocumentRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(Guid id);
	}
}

/*<Codenesium>
    <Hash>453744ca30e92ea6be215cf1b60670f8</Hash>
</Codenesium>*/