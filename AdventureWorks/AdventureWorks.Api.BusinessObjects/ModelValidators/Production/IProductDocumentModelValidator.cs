using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductDocumentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDocumentModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDocumentModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6b2b65eb0464b2b45430d1b8513c6876</Hash>
</Codenesium>*/