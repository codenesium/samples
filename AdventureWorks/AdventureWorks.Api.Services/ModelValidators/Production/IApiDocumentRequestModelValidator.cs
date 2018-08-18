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
    <Hash>5b7fc6183d0e7930b4c63d5ea48871e5</Hash>
</Codenesium>*/