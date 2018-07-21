using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractSchemaVersionsService : AbstractService
        {
                private ISchemaVersionsRepository schemaVersionsRepository;

                private IApiSchemaVersionsRequestModelValidator schemaVersionsModelValidator;

                private IBOLSchemaVersionsMapper bolSchemaVersionsMapper;

                private IDALSchemaVersionsMapper dalSchemaVersionsMapper;

                private ILogger logger;

                public AbstractSchemaVersionsService(
                        ILogger logger,
                        ISchemaVersionsRepository schemaVersionsRepository,
                        IApiSchemaVersionsRequestModelValidator schemaVersionsModelValidator,
                        IBOLSchemaVersionsMapper bolSchemaVersionsMapper,
                        IDALSchemaVersionsMapper dalSchemaVersionsMapper)
                        : base()
                {
                        this.schemaVersionsRepository = schemaVersionsRepository;
                        this.schemaVersionsModelValidator = schemaVersionsModelValidator;
                        this.bolSchemaVersionsMapper = bolSchemaVersionsMapper;
                        this.dalSchemaVersionsMapper = dalSchemaVersionsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSchemaVersionsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.schemaVersionsRepository.All(limit, offset);

                        return this.bolSchemaVersionsMapper.MapBOToModel(this.dalSchemaVersionsMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSchemaVersionsResponseModel> Get(int id)
                {
                        var record = await this.schemaVersionsRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSchemaVersionsMapper.MapBOToModel(this.dalSchemaVersionsMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSchemaVersionsResponseModel>> Create(
                        ApiSchemaVersionsRequestModel model)
                {
                        CreateResponse<ApiSchemaVersionsResponseModel> response = new CreateResponse<ApiSchemaVersionsResponseModel>(await this.schemaVersionsModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSchemaVersionsMapper.MapModelToBO(default(int), model);
                                var record = await this.schemaVersionsRepository.Create(this.dalSchemaVersionsMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSchemaVersionsMapper.MapBOToModel(this.dalSchemaVersionsMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSchemaVersionsResponseModel>> Update(
                        int id,
                        ApiSchemaVersionsRequestModel model)
                {
                        var validationResult = await this.schemaVersionsModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSchemaVersionsMapper.MapModelToBO(id, model);
                                await this.schemaVersionsRepository.Update(this.dalSchemaVersionsMapper.MapBOToEF(bo));

                                var record = await this.schemaVersionsRepository.Get(id);

                                return new UpdateResponse<ApiSchemaVersionsResponseModel>(this.bolSchemaVersionsMapper.MapBOToModel(this.dalSchemaVersionsMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSchemaVersionsResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.schemaVersionsModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.schemaVersionsRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>71b386d737051c2e2b10bee259900550</Hash>
</Codenesium>*/