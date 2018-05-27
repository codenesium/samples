using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductDocumentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDocumentRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDocumentRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7000f26fb0d450344d84e750b42c6ec8</Hash>
</Codenesium>*/