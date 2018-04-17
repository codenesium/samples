using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IDocumentModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(DocumentModel model);
		Task<ValidationResult>  ValidateUpdateAsync(Guid id, DocumentModel model);
		Task<ValidationResult>  ValidateDeleteAsync(Guid id);
	}
}

/*<Codenesium>
    <Hash>8ea44c0a9d8fef9e512fe6b62f526c64</Hash>
</Codenesium>*/