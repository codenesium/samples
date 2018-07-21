using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiSchemaAPersonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSchemaAPersonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaAPersonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>21a518792b6a29c2dfc0d615e02031ff</Hash>
</Codenesium>*/