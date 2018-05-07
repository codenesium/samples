using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductPhotoModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductPhotoModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductPhotoModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cf8c81744fed2f88efa249da906880c2</Hash>
</Codenesium>*/