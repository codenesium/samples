using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductDocumentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductDocumentModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductDocumentModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fa8628bf331a16af3531c89e4a8f1b4e</Hash>
</Codenesium>*/