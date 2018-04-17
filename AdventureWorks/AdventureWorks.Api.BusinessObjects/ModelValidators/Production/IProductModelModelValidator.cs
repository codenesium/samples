using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductModelModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductModelModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductModelModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8761804d68b5707feddab1c3d0463f5c</Hash>
</Codenesium>*/