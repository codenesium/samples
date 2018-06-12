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
        public abstract class AbstractChannelService: AbstractService
        {
                private IChannelRepository channelRepository;

                private IApiChannelRequestModelValidator channelModelValidator;

                private IBOLChannelMapper bolChannelMapper;

                private IDALChannelMapper dalChannelMapper;

                private ILogger logger;

                public AbstractChannelService(
                        ILogger logger,
                        IChannelRepository channelRepository,
                        IApiChannelRequestModelValidator channelModelValidator,
                        IBOLChannelMapper bolchannelMapper,
                        IDALChannelMapper dalchannelMapper)
                        : base()

                {
                        this.channelRepository = channelRepository;
                        this.channelModelValidator = channelModelValidator;
                        this.bolChannelMapper = bolchannelMapper;
                        this.dalChannelMapper = dalchannelMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiChannelResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.channelRepository.All(skip, take, orderClause);

                        return this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiChannelResponseModel> Get(string id)
                {
                        var record = await this.channelRepository.Get(id);

                        return this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiChannelResponseModel>> Create(
                        ApiChannelRequestModel model)
                {
                        CreateResponse<ApiChannelResponseModel> response = new CreateResponse<ApiChannelResponseModel>(await this.channelModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolChannelMapper.MapModelToBO(default (string), model);
                                var record = await this.channelRepository.Create(this.dalChannelMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiChannelRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.channelModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolChannelMapper.MapModelToBO(id, model);
                                await this.channelRepository.Update(this.dalChannelMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.channelModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.channelRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiChannelResponseModel> GetNameProjectId(string name, string projectId)
                {
                        Channel record = await this.channelRepository.GetNameProjectId(name, projectId);

                        return this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(record));
                }
                public async Task<List<ApiChannelResponseModel>> GetDataVersion(byte[] dataVersion)
                {
                        List<Channel> records = await this.channelRepository.GetDataVersion(dataVersion);

                        return this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(records));
                }
                public async Task<List<ApiChannelResponseModel>> GetProjectId(string projectId)
                {
                        List<Channel> records = await this.channelRepository.GetProjectId(projectId);

                        return this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>f22412c12f7d80cb1fb6ffaa8429cc74</Hash>
</Codenesium>*/