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
                        IBOLChannelMapper bolChannelMapper,
                        IDALChannelMapper dalChannelMapper

                        )
                        : base()

                {
                        this.channelRepository = channelRepository;
                        this.channelModelValidator = channelModelValidator;
                        this.bolChannelMapper = bolChannelMapper;
                        this.dalChannelMapper = dalChannelMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiChannelResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.channelRepository.All(limit, offset);

                        return this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiChannelResponseModel> Get(string id)
                {
                        var record = await this.channelRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(record));
                        }
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

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolChannelMapper.MapBOToModel(this.dalChannelMapper.MapEFToBO(record));
                        }
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
    <Hash>75632fafa9c190ca517436105d0b0aeb</Hash>
</Codenesium>*/