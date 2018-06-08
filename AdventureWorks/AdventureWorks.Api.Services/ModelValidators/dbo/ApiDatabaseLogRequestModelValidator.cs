using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiDatabaseLogRequestModelValidator: AbstractApiDatabaseLogRequestModelValidator, IApiDatabaseLogRequestModelValidator
        {
                public ApiDatabaseLogRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogRequestModel model)
                {
                        this.DatabaseUserRules();
                        this.@EventRules();
                        this.@ObjectRules();
                        this.PostTimeRules();
                        this.SchemaRules();
                        this.TSQLRules();
                        this.XmlEventRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogRequestModel model)
                {
                        this.DatabaseUserRules();
                        this.@EventRules();
                        this.@ObjectRules();
                        this.PostTimeRules();
                        this.SchemaRules();
                        this.TSQLRules();
                        this.XmlEventRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>4715e4e467d85412563715f4512f0ba9</Hash>
</Codenesium>*/