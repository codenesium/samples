using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiLocationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLocationModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>485a413655f9234335656f990bc4a4fd</Hash>
</Codenesium>*/