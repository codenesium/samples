using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractSchemaVersionsService: AbstractService
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
                        IBOLSchemaVersionsMapper bolschemaVersionsMapper,
                        IDALSchemaVersionsMapper dalschemaVersionsMapper)
                        : base()

                {
                        this.schemaVersionsRepository = schemaVersionsRepository;
                        this.schemaVersionsModelValidator = schemaVersionsModelValidator;
                        this.bolSchemaVersionsMapper = bolschemaVersionsMapper;
                        this.dalSchemaVersionsMapper = dalschemaVersionsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSchemaVersionsResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.schemaVersionsRepository.All(skip, take, orderClause);

                        return this.bolSchemaVersionsMapper.MapBOToModel(this.dalSchemaVersionsMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSchemaVersionsResponseModel> Get(int id)
                {
                        var record = await this.schemaVersionsRepository.Get(id);

                        return this.bolSchemaVersionsMapper.MapBOToModel(this.dalSchemaVersionsMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiSchemaVersionsResponseModel>> Create(
                        ApiSchemaVersionsRequestModel model)
                {
                        CreateResponse<ApiSchemaVersionsResponseModel> response = new CreateResponse<ApiSchemaVersionsResponseModel>(await this.schemaVersionsModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSchemaVersionsMapper.MapModelToBO(default (int), model);
                                var record = await this.schemaVersionsRepository.Create(this.dalSchemaVersionsMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSchemaVersionsMapper.MapBOToModel(this.dalSchemaVersionsMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiSchemaVersionsRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.schemaVersionsModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolSchemaVersionsMapper.MapModelToBO(id, model);
                                await this.schemaVersionsRepository.Update(this.dalSchemaVersionsMapper.MapBOToEF(bo));
                        }

                        return response;
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
    <Hash>fee40a12e9e74acdfb4121332aae2d56</Hash>
</Codenesium>*/