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
	public abstract class AbstractChannelService : AbstractService
	{
		protected IChannelRepository ChannelRepository { get; private set; }

		protected IApiChannelRequestModelValidator ChannelModelValidator { get; private set; }

		protected IBOLChannelMapper BolChannelMapper { get; private set; }

		protected IDALChannelMapper DalChannelMapper { get; private set; }

		private ILogger logger;

		public AbstractChannelService(
			ILogger logger,
			IChannelRepository channelRepository,
			IApiChannelRequestModelValidator channelModelValidator,
			IBOLChannelMapper bolChannelMapper,
			IDALChannelMapper dalChannelMapper)
			: base()
		{
			this.ChannelRepository = channelRepository;
			this.ChannelModelValidator = channelModelValidator;
			this.BolChannelMapper = bolChannelMapper;
			this.DalChannelMapper = dalChannelMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiChannelResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ChannelRepository.All(limit, offset);

			return this.BolChannelMapper.MapBOToModel(this.DalChannelMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiChannelResponseModel> Get(string id)
		{
			var record = await this.ChannelRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolChannelMapper.MapBOToModel(this.DalChannelMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiChannelResponseModel>> Create(
			ApiChannelRequestModel model)
		{
			CreateResponse<ApiChannelResponseModel> response = new CreateResponse<ApiChannelResponseModel>(await this.ChannelModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolChannelMapper.MapModelToBO(default(string), model);
				var record = await this.ChannelRepository.Create(this.DalChannelMapper.MapBOToEF(bo));

				response.SetRecord(this.BolChannelMapper.MapBOToModel(this.DalChannelMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiChannelResponseModel>> Update(
			string id,
			ApiChannelRequestModel model)
		{
			var validationResult = await this.ChannelModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolChannelMapper.MapModelToBO(id, model);
				await this.ChannelRepository.Update(this.DalChannelMapper.MapBOToEF(bo));

				var record = await this.ChannelRepository.Get(id);

				return new UpdateResponse<ApiChannelResponseModel>(this.BolChannelMapper.MapBOToModel(this.DalChannelMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiChannelResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ChannelModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ChannelRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiChannelResponseModel> ByNameProjectId(string name, string projectId)
		{
			Channel record = await this.ChannelRepository.ByNameProjectId(name, projectId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolChannelMapper.MapBOToModel(this.DalChannelMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiChannelResponseModel>> ByDataVersion(byte[] dataVersion, int limit = 0, int offset = int.MaxValue)
		{
			List<Channel> records = await this.ChannelRepository.ByDataVersion(dataVersion, limit, offset);

			return this.BolChannelMapper.MapBOToModel(this.DalChannelMapper.MapEFToBO(records));
		}

		public async Task<List<ApiChannelResponseModel>> ByProjectId(string projectId, int limit = 0, int offset = int.MaxValue)
		{
			List<Channel> records = await this.ChannelRepository.ByProjectId(projectId, limit, offset);

			return this.BolChannelMapper.MapBOToModel(this.DalChannelMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>19bc6fd1af79169f85be0186c416c6de</Hash>
</Codenesium>*/