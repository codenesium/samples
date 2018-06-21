using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSpecialOfferProductRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferProductRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferProductRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>79672a190c1298c2cadb3bb41d7144ea</Hash>
</Codenesium>*/