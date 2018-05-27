using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiDocumentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDocumentRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(Guid id, ApiDocumentRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(Guid id);
	}
}

/*<Codenesium>
    <Hash>463861ea54fbd24dbb7b72d785d8aab6</Hash>
</Codenesium>*/