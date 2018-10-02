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
	public abstract class AbstractDirectTweetService : AbstractService
	{
		protected IDirectTweetRepository DirectTweetRepository { get; private set; }

		protected IApiDirectTweetRequestModelValidator DirectTweetModelValidator { get; private set; }

		protected IBOLDirectTweetMapper BolDirectTweetMapper { get; private set; }

		protected IDALDirectTweetMapper DalDirectTweetMapper { get; private set; }

		private ILogger logger;

		public AbstractDirectTweetService(
			ILogger logger,
			IDirectTweetRepository directTweetRepository,
			IApiDirectTweetRequestModelValidator directTweetModelValidator,
			IBOLDirectTweetMapper bolDirectTweetMapper,
			IDALDirectTweetMapper dalDirectTweetMapper)
			: base()
		{
			this.DirectTweetRepository = directTweetRepository;
			this.DirectTweetModelValidator = directTweetModelValidator;
			this.BolDirectTweetMapper = bolDirectTweetMapper;
			this.DalDirectTweetMapper = dalDirectTweetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDirectTweetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DirectTweetRepository.All(limit, offset);

			return this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDirectTweetResponseModel> Get(int tweetId)
		{
			var record = await this.DirectTweetRepository.Get(tweetId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDirectTweetResponseModel>> Create(
			ApiDirectTweetRequestModel model)
		{
			CreateResponse<ApiDirectTweetResponseModel> response = new CreateResponse<ApiDirectTweetResponseModel>(await this.DirectTweetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDirectTweetMapper.MapModelToBO(default(int), model);
				var record = await this.DirectTweetRepository.Create(this.DalDirectTweetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDirectTweetResponseModel>> Update(
			int tweetId,
			ApiDirectTweetRequestModel model)
		{
			var validationResult = await this.DirectTweetModelValidator.ValidateUpdateAsync(tweetId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDirectTweetMapper.MapModelToBO(tweetId, model);
				await this.DirectTweetRepository.Update(this.DalDirectTweetMapper.MapBOToEF(bo));

				var record = await this.DirectTweetRepository.Get(tweetId);

				return new UpdateResponse<ApiDirectTweetResponseModel>(this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDirectTweetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int tweetId)
		{
			ActionResponse response = new ActionResponse(await this.DirectTweetModelValidator.ValidateDeleteAsync(tweetId));
			if (response.Success)
			{
				await this.DirectTweetRepository.Delete(tweetId);
			}

			return response;
		}

		public async Task<List<ApiDirectTweetResponseModel>> ByTaggedUserId(int taggedUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<DirectTweet> records = await this.DirectTweetRepository.ByTaggedUserId(taggedUserId, limit, offset);

			return this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>86e1278347588f3cbe4c5d7f7be1dd51</Hash>
</Codenesium>*/