using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDocumentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDocumentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(Guid id, ApiDocumentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(Guid id);
	}
}

/*<Codenesium>
    <Hash>94f544008da22255493b40f05ea7df5a</Hash>
</Codenesium>*/