using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductDocumentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDocumentRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDocumentRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>22e05c5ff94d0af4772ffb0bb3754813</Hash>
</Codenesium>*/