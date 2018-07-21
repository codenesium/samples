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
        public abstract class AbstractTestAllFieldTypesNullableService : AbstractService
        {
                private ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository;

                private IApiTestAllFieldTypesNullableRequestModelValidator testAllFieldTypesNullableModelValidator;

                private IBOLTestAllFieldTypesNullableMapper bolTestAllFieldTypesNullableMapper;

                private IDALTestAllFieldTypesNullableMapper dalTestAllFieldTypesNullableMapper;

                private ILogger logger;

                public AbstractTestAllFieldTypesNullableService(
                        ILogger logger,
                        ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository,
                        IApiTestAllFieldTypesNullableRequestModelValidator testAllFieldTypesNullableModelValidator,
                        IBOLTestAllFieldTypesNullableMapper bolTestAllFieldTypesNullableMapper,
                        IDALTestAllFieldTypesNullableMapper dalTestAllFieldTypesNullableMapper)
                        : base()
                {
                        this.testAllFieldTypesNullableRepository = testAllFieldTypesNullableRepository;
                        this.testAllFieldTypesNullableModelValidator = testAllFieldTypesNullableModelValidator;
                        this.bolTestAllFieldTypesNullableMapper = bolTestAllFieldTypesNullableMapper;
                        this.dalTestAllFieldTypesNullableMapper = dalTestAllFieldTypesNullableMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTestAllFieldTypesNullableResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.testAllFieldTypesNullableRepository.All(limit, offset);

                        return this.bolTestAllFieldTypesNullableMapper.MapBOToModel(this.dalTestAllFieldTypesNullableMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTestAllFieldTypesNullableResponseModel> Get(int id)
                {
                        var record = await this.testAllFieldTypesNullableRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolTestAllFieldTypesNullableMapper.MapBOToModel(this.dalTestAllFieldTypesNullableMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>> Create(
                        ApiTestAllFieldTypesNullableRequestModel model)
                {
                        CreateResponse<ApiTestAllFieldTypesNullableResponseModel> response = new CreateResponse<ApiTestAllFieldTypesNullableResponseModel>(await this.testAllFieldTypesNullableModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTestAllFieldTypesNullableMapper.MapModelToBO(default(int), model);
                                var record = await this.testAllFieldTypesNullableRepository.Create(this.dalTestAllFieldTypesNullableMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTestAllFieldTypesNullableMapper.MapBOToModel(this.dalTestAllFieldTypesNullableMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>> Update(
                        int id,
                        ApiTestAllFieldTypesNullableRequestModel model)
                {
                        var validationResult = await this.testAllFieldTypesNullableModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolTestAllFieldTypesNullableMapper.MapModelToBO(id, model);
                                await this.testAllFieldTypesNullableRepository.Update(this.dalTestAllFieldTypesNullableMapper.MapBOToEF(bo));

                                var record = await this.testAllFieldTypesNullableRepository.Get(id);

                                return new UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>(this.bolTestAllFieldTypesNullableMapper.MapBOToModel(this.dalTestAllFieldTypesNullableMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.testAllFieldTypesNullableModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.testAllFieldTypesNullableRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8533fec280543fb35873e5ed31de7baa</Hash>
</Codenesium>*/