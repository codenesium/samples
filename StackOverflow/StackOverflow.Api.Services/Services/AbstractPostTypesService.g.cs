using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractPostTypesService : AbstractService
        {
                private IPostTypesRepository postTypesRepository;

                private IApiPostTypesRequestModelValidator postTypesModelValidator;

                private IBOLPostTypesMapper bolPostTypesMapper;

                private IDALPostTypesMapper dalPostTypesMapper;

                private ILogger logger;

                public AbstractPostTypesService(
                        ILogger logger,
                        IPostTypesRepository postTypesRepository,
                        IApiPostTypesRequestModelValidator postTypesModelValidator,
                        IBOLPostTypesMapper bolPostTypesMapper,
                        IDALPostTypesMapper dalPostTypesMapper)
                        : base()
                {
                        this.postTypesRepository = postTypesRepository;
                        this.postTypesModelValidator = postTypesModelValidator;
                        this.bolPostTypesMapper = bolPostTypesMapper;
                        this.dalPostTypesMapper = dalPostTypesMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPostTypesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.postTypesRepository.All(limit, offset);

                        return this.bolPostTypesMapper.MapBOToModel(this.dalPostTypesMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPostTypesResponseModel> Get(int id)
                {
                        var record = await this.postTypesRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPostTypesMapper.MapBOToModel(this.dalPostTypesMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPostTypesResponseModel>> Create(
                        ApiPostTypesRequestModel model)
                {
                        CreateResponse<ApiPostTypesResponseModel> response = new CreateResponse<ApiPostTypesResponseModel>(await this.postTypesModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPostTypesMapper.MapModelToBO(default(int), model);
                                var record = await this.postTypesRepository.Create(this.dalPostTypesMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPostTypesMapper.MapBOToModel(this.dalPostTypesMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiPostTypesRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.postTypesModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolPostTypesMapper.MapModelToBO(id, model);
                                await this.postTypesRepository.Update(this.dalPostTypesMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.postTypesModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.postTypesRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>04b99cb6188d38e29b544d5a987f19b7</Hash>
</Codenesium>*/