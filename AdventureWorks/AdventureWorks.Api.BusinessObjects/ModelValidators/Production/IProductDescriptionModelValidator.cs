using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductDescriptionModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f3f13eb7f3dc5763c952c6386b6d9e68</Hash>
</Codenesium>*/