using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IDocumentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(DocumentModel model);
		Task<ValidationResult> ValidateUpdateAsync(Guid id, DocumentModel model);
		Task<ValidationResult> ValidateDeleteAsync(Guid id);
	}
}

/*<Codenesium>
    <Hash>a9d3b91358cf00de42f054805d9dc251</Hash>
</Codenesium>*/