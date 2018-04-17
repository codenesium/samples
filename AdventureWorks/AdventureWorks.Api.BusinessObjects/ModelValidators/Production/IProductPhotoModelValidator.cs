using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductPhotoModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductPhotoModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductPhotoModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6fa1c8a48f7612b9ed76a299ccacca70</Hash>
</Codenesium>*/