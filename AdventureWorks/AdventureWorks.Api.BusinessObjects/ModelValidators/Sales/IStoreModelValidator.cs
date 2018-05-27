using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiStoreRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStoreRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b172d988298a54845a65def04e3d9b61</Hash>
</Codenesium>*/