using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductProductPhotoModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductProductPhotoModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductProductPhotoModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2497de8648b39701e77d12c4c6a400a5</Hash>
</Codenesium>*/