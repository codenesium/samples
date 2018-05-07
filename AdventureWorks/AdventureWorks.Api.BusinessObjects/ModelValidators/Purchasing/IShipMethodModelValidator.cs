using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IShipMethodModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ShipMethodModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ShipMethodModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d1f7ae772de8a7e0806736d9d90f1be2</Hash>
</Codenesium>*/