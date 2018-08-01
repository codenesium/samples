using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>1b43593a82c5431120ec5f3cf56a9104</Hash>
</Codenesium>*/