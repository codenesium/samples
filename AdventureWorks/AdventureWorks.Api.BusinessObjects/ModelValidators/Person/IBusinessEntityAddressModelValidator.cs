using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBusinessEntityAddressModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(BusinessEntityAddressModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, BusinessEntityAddressModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>922532418a738b2b977449af2022a5ae</Hash>
</Codenesium>*/