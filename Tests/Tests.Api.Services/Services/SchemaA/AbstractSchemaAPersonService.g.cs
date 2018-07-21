using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class AbstractSchemaAPersonService : AbstractService
        {
                private ISchemaAPersonRepository schemaAPersonRepository;

                private IApiSchemaAPersonRequestModelValidator schemaAPersonModelValidator;

                private IBOLSchemaAPersonMapper bolSchemaAPersonMapper;

                private IDALSchemaAPersonMapper dalSchemaAPersonMapper;

                private ILogger logger;

                public AbstractSchemaAPersonService(
                        ILogger logger,
                        ISchemaAPersonRepository schemaAPersonRepository,
                        IApiSchemaAPersonRequestModelValidator schemaAPersonModelValidator,
                        IBOLSchemaAPersonMapper bolSchemaAPersonMapper,
                        IDALSchemaAPersonMapper dalSchemaAPersonMapper)
                        : base()
                {
                        this.schemaAPersonRepository = schemaAPersonRepository;
                        this.schemaAPersonModelValidator = schemaAPersonModelValidator;
                        this.bolSchemaAPersonMapper = bolSchemaAPersonMapper;
                        this.dalSchemaAPersonMapper = dalSchemaAPersonMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSchemaAPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.schemaAPersonRepository.All(limit, offset);

                        return this.bolSchemaAPersonMapper.MapBOToModel(this.dalSchemaAPersonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSchemaAPersonResponseModel> Get(int id)
                {
                        var record = await this.schemaAPersonRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSchemaAPersonMapper.MapBOToModel(this.dalSchemaAPersonMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSchemaAPersonResponseModel>> Create(
                        ApiSchemaAPersonRequestModel model)
                {
                        CreateResponse<ApiSchemaAPersonResponseModel> response = new CreateResponse<ApiSchemaAPersonResponseModel>(await this.schemaAPersonModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSchemaAPersonMapper.MapModelToBO(default(int), model);
                                var record = await this.schemaAPersonRepository.Create(this.dalSchemaAPersonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSchemaAPersonMapper.MapBOToModel(this.dalSchemaAPersonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSchemaAPersonResponseModel>> Update(
                        int id,
                        ApiSchemaAPersonRequestModel model)
                {
                        var validationResult = await this.schemaAPersonModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSchemaAPersonMapper.MapModelToBO(id, model);
                                await this.schemaAPersonRepository.Update(this.dalSchemaAPersonMapper.MapBOToEF(bo));

                                var record = await this.schemaAPersonRepository.Get(id);

                                return new UpdateResponse<ApiSchemaAPersonResponseModel>(this.bolSchemaAPersonMapper.MapBOToModel(this.dalSchemaAPersonMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSchemaAPersonResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.schemaAPersonModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.schemaAPersonRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>73fc337b233ca38562ca0e829c4d06c4</Hash>
</Codenesium>*/