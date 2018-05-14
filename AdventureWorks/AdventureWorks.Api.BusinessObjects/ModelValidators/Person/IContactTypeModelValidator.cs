using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiContactTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiContactTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>50598d672ee7e18c8f2c4c465a766eb5</Hash>
</Codenesium>*/