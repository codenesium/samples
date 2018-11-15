using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractDirectTweetService : AbstractService
	{
		protected IDirectTweetRepository DirectTweetRepository { get; private set; }

		protected IApiDirectTweetServerRequestModelValidator DirectTweetModelValidator { get; private set; }

		protected IBOLDirectTweetMapper BolDirectTweetMapper { get; private set; }

		protected IDALDirectTweetMapper DalDirectTweetMapper { get; private set; }

		private ILogger logger;

		public AbstractDirectTweetService(
			ILogger logger,
			IDirectTweetRepository directTweetRepository,
			IApiDirectTweetServerRequestModelValidator directTweetModelValidator,
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

		public virtual async Task<List<ApiDirectTweetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DirectTweetRepository.All(limit, offset);

			return this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDirectTweetServerResponseModel> Get(int tweetId)
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

		public virtual async Task<CreateResponse<ApiDirectTweetServerResponseModel>> Create(
			ApiDirectTweetServerRequestModel model)
		{
			CreateResponse<ApiDirectTweetServerResponseModel> response = ValidationResponseFactory<ApiDirectTweetServerResponseModel>.CreateResponse(await this.DirectTweetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolDirectTweetMapper.MapModelToBO(default(int), model);
				var record = await this.DirectTweetRepository.Create(this.DalDirectTweetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDirectTweetServerResponseModel>> Update(
			int tweetId,
			ApiDirectTweetServerRequestModel model)
		{
			var validationResult = await this.DirectTweetModelValidator.ValidateUpdateAsync(tweetId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDirectTweetMapper.MapModelToBO(tweetId, model);
				await this.DirectTweetRepository.Update(this.DalDirectTweetMapper.MapBOToEF(bo));

				var record = await this.DirectTweetRepository.Get(tweetId);

				return ValidationResponseFactory<ApiDirectTweetServerResponseModel>.UpdateResponse(this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiDirectTweetServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int tweetId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DirectTweetModelValidator.ValidateDeleteAsync(tweetId));

			if (response.Success)
			{
				await this.DirectTweetRepository.Delete(tweetId);
			}

			return response;
		}

		public async virtual Task<List<ApiDirectTweetServerResponseModel>> ByTaggedUserId(int taggedUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<DirectTweet> records = await this.DirectTweetRepository.ByTaggedUserId(taggedUserId, limit, offset);

			return this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e077a1292389ebdd256fd5b360297d77</Hash>
</Codenesium>*/