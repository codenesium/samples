using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductModelIllustrationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductModelIllustrationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductModelIllustrationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ae10fddcd272cca2f8d667cd45bbbfaf</Hash>
</Codenesium>*/