using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductModelProductDescriptionCultureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2b23368d05051df236f7560d2f933708</Hash>
</Codenesium>*/