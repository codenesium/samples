using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductModelIllustrationModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductModelIllustrationModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductModelIllustrationModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2d50347257a22dc0b36bcc833b79906f</Hash>
</Codenesium>*/