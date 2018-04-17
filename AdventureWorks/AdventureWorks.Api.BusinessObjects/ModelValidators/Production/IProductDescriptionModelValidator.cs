using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductDescriptionModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductDescriptionModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductDescriptionModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7e913d3982bf7cfd19914dbfd156c834</Hash>
</Codenesium>*/