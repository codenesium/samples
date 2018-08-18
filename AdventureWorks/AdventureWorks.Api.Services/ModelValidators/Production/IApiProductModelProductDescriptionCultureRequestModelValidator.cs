using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductModelProductDescriptionCultureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bba78085adc3cb1ca9c5160533c22b08</Hash>
</Codenesium>*/