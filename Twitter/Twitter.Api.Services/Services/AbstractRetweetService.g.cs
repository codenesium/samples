using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractRetweetService : AbstractService
	{
		protected IRetweetRepository RetweetRepository { get; private set; }

		protected IApiRetweetServerRequestModelValidator RetweetModelValidator { get; private set; }

		protected IBOLRetweetMapper BolRetweetMapper { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		private ILogger logger;

		public AbstractRetweetService(
			ILogger logger,
			IRetweetRepository retweetRepository,
			IApiRetweetServerRequestModelValidator retweetModelValidator,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base()
		{
			this.RetweetRepository = retweetRepository;
			this.RetweetModelValidator = retweetModelValidator;
			this.BolRetweetMapper = bolRetweetMapper;
			this.DalRetweetMapper = dalRetweetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiRetweetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.RetweetRepository.All(limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiRetweetServerResponseModel> Get(int id)
		{
			var record = await this.RetweetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiRetweetServerResponseModel>> Create(
			ApiRetweetServerRequestModel model)
		{
			CreateResponse<ApiRetweetServerResponseModel> response = ValidationResponseFactory<ApiRetweetServerResponseModel>.CreateResponse(await this.RetweetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolRetweetMapper.MapModelToBO(default(int), model);
				var record = await this.RetweetRepository.Create(this.DalRetweetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRetweetServerResponseModel>> Update(
			int id,
			ApiRetweetServerRequestModel model)
		{
			var validationResult = await this.RetweetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolRetweetMapper.MapModelToBO(id, model);
				await this.RetweetRepository.Update(this.DalRetweetMapper.MapBOToEF(bo));

				var record = await this.RetweetRepository.Get(id);

				return ValidationResponseFactory<ApiRetweetServerResponseModel>.UpdateResponse(this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiRetweetServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.RetweetModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.RetweetRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiRetweetServerResponseModel>> ByRetwitterUserId(int? retwitterUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Retweet> records = await this.RetweetRepository.ByRetwitterUserId(retwitterUserId, limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRetweetServerResponseModel>> ByTweetTweetId(int tweetTweetId, int limit = 0, int offset = int.MaxValue)
		{
			List<Retweet> records = await this.RetweetRepository.ByTweetTweetId(tweetTweetId, limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1f040dc8bca5cfa61281d4b9c3f3d51e</Hash>
</Codenesium>*/