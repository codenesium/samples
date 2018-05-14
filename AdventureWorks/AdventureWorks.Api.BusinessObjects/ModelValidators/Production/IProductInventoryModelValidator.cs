using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductInventoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductInventoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductInventoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>58ba493b826e217a493bf98887203dee</Hash>
</Codenesium>*/