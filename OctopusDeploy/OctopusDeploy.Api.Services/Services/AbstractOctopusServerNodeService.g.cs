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
        public abstract class AbstractOctopusServerNodeService : AbstractService
        {
                private IOctopusServerNodeRepository octopusServerNodeRepository;

                private IApiOctopusServerNodeRequestModelValidator octopusServerNodeModelValidator;

                private IBOLOctopusServerNodeMapper bolOctopusServerNodeMapper;

                private IDALOctopusServerNodeMapper dalOctopusServerNodeMapper;

                private ILogger logger;

                public AbstractOctopusServerNodeService(
                        ILogger logger,
                        IOctopusServerNodeRepository octopusServerNodeRepository,
                        IApiOctopusServerNodeRequestModelValidator octopusServerNodeModelValidator,
                        IBOLOctopusServerNodeMapper bolOctopusServerNodeMapper,
                        IDALOctopusServerNodeMapper dalOctopusServerNodeMapper)
                        : base()
                {
                        this.octopusServerNodeRepository = octopusServerNodeRepository;
                        this.octopusServerNodeModelValidator = octopusServerNodeModelValidator;
                        this.bolOctopusServerNodeMapper = bolOctopusServerNodeMapper;
                        this.dalOctopusServerNodeMapper = dalOctopusServerNodeMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiOctopusServerNodeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.octopusServerNodeRepository.All(limit, offset);

                        return this.bolOctopusServerNodeMapper.MapBOToModel(this.dalOctopusServerNodeMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiOctopusServerNodeResponseModel> Get(string id)
                {
                        var record = await this.octopusServerNodeRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolOctopusServerNodeMapper.MapBOToModel(this.dalOctopusServerNodeMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiOctopusServerNodeResponseModel>> Create(
                        ApiOctopusServerNodeRequestModel model)
                {
                        CreateResponse<ApiOctopusServerNodeResponseModel> response = new CreateResponse<ApiOctopusServerNodeResponseModel>(await this.octopusServerNodeModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolOctopusServerNodeMapper.MapModelToBO(default(string), model);
                                var record = await this.octopusServerNodeRepository.Create(this.dalOctopusServerNodeMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolOctopusServerNodeMapper.MapBOToModel(this.dalOctopusServerNodeMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiOctopusServerNodeRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.octopusServerNodeModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolOctopusServerNodeMapper.MapModelToBO(id, model);
                                await this.octopusServerNodeRepository.Update(this.dalOctopusServerNodeMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.octopusServerNodeModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.octopusServerNodeRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>976d357315ec752f57f8d017f29449b4</Hash>
</Codenesium>*/