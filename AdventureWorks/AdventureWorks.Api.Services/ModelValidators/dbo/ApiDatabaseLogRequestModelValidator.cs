using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiDatabaseLogRequestModelValidator : AbstractApiDatabaseLogRequestModelValidator, IApiDatabaseLogRequestModelValidator
        {
                public ApiDatabaseLogRequestModelValidator(IDatabaseLogRepository databaseLogRepository)
                        : base(databaseLogRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>312f2eecaf4a02b455ea53b1a1e93385</Hash>
</Codenesium>*/