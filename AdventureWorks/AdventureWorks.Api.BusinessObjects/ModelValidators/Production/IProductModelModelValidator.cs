using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductModelModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a4dbed8c27fe18953f15307b740ead7d</Hash>
</Codenesium>*/