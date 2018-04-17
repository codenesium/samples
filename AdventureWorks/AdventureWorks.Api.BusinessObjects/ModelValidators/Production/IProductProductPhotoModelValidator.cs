using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductProductPhotoModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductProductPhotoModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductProductPhotoModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3eb945a5be6293ef685b4124cbe1c2d0</Hash>
</Codenesium>*/