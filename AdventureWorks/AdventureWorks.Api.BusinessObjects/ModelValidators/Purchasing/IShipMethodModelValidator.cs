using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IShipMethodModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ShipMethodModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ShipMethodModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c37b4fd395e7b925e3f65a247c95da36</Hash>
</Codenesium>*/