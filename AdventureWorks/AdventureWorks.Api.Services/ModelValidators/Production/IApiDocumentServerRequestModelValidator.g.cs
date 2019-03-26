using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDocumentServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDocumentServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(Guid id, ApiDocumentServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(Guid id);
	}
}

/*<Codenesium>
    <Hash>79c16afc5888ba77107f718b018a69a4</Hash>
</Codenesium>*/