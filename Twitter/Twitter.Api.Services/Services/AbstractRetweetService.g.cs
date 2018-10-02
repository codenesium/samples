using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractRetweetService : AbstractService
	{
		protected IRetweetRepository RetweetRepository { get; private set; }

		protected IApiRetweetRequestModelValidator RetweetModelValidator { get; private set; }

		protected IBOLRetweetMapper BolRetweetMapper { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		private ILogger logger;

		public AbstractRetweetService(
			ILogger logger,
			IRetweetRepository retweetRepository,
			IApiRetweetRequestModelValidator retweetModelValidator,
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

		public virtual async Task<List<ApiRetweetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.RetweetRepository.All(limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiRetweetResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiRetweetResponseModel>> Create(
			ApiRetweetRequestModel model)
		{
			CreateResponse<ApiRetweetResponseModel> response = new CreateResponse<ApiRetweetResponseModel>(await this.RetweetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolRetweetMapper.MapModelToBO(default(int), model);
				var record = await this.RetweetRepository.Create(this.DalRetweetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRetweetResponseModel>> Update(
			int id,
			ApiRetweetRequestModel model)
		{
			var validationResult = await this.RetweetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolRetweetMapper.MapModelToBO(id, model);
				await this.RetweetRepository.Update(this.DalRetweetMapper.MapBOToEF(bo));

				var record = await this.RetweetRepository.Get(id);

				return new UpdateResponse<ApiRetweetResponseModel>(this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiRetweetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.RetweetModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.RetweetRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiRetweetResponseModel>> ByRetwitterUserId(int? retwitterUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Retweet> records = await this.RetweetRepository.ByRetwitterUserId(retwitterUserId, limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}

		public async Task<List<ApiRetweetResponseModel>> ByTweetTweetId(int tweetTweetId, int limit = 0, int offset = int.MaxValue)
		{
			List<Retweet> records = await this.RetweetRepository.ByTweetTweetId(tweetTweetId, limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>535bff1418af0e04fa908fd4b5dfbca5</Hash>
</Codenesium>*/