using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductDocumentModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductDocumentModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductDocumentModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>92f0130135e153043e9b3a7083fe5690</Hash>
</Codenesium>*/