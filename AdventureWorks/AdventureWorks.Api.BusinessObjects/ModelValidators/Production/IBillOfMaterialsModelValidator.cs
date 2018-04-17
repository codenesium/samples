using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBillOfMaterialsModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(BillOfMaterialsModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, BillOfMaterialsModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fe4d3847229dedb23aeaf4cef1e2cb33</Hash>
</Codenesium>*/