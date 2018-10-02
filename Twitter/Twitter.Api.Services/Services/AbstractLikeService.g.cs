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
	public abstract class AbstractLikeService : AbstractService
	{
		protected ILikeRepository LikeRepository { get; private set; }

		protected IApiLikeRequestModelValidator LikeModelValidator { get; private set; }

		protected IBOLLikeMapper BolLikeMapper { get; private set; }

		protected IDALLikeMapper DalLikeMapper { get; private set; }

		private ILogger logger;

		public AbstractLikeService(
			ILogger logger,
			ILikeRepository likeRepository,
			IApiLikeRequestModelValidator likeModelValidator,
			IBOLLikeMapper bolLikeMapper,
			IDALLikeMapper dalLikeMapper)
			: base()
		{
			this.LikeRepository = likeRepository;
			this.LikeModelValidator = likeModelValidator;
			this.BolLikeMapper = bolLikeMapper;
			this.DalLikeMapper = dalLikeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLikeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LikeRepository.All(limit, offset);

			return this.BolLikeMapper.MapBOToModel(this.DalLikeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLikeResponseModel> Get(int likeId)
		{
			var record = await this.LikeRepository.Get(likeId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLikeMapper.MapBOToModel(this.DalLikeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLikeResponseModel>> Create(
			ApiLikeRequestModel model)
		{
			CreateResponse<ApiLikeResponseModel> response = new CreateResponse<ApiLikeResponseModel>(await this.LikeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLikeMapper.MapModelToBO(default(int), model);
				var record = await this.LikeRepository.Create(this.DalLikeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLikeMapper.MapBOToModel(this.DalLikeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLikeResponseModel>> Update(
			int likeId,
			ApiLikeRequestModel model)
		{
			var validationResult = await this.LikeModelValidator.ValidateUpdateAsync(likeId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLikeMapper.MapModelToBO(likeId, model);
				await this.LikeRepository.Update(this.DalLikeMapper.MapBOToEF(bo));

				var record = await this.LikeRepository.Get(likeId);

				return new UpdateResponse<ApiLikeResponseModel>(this.BolLikeMapper.MapBOToModel(this.DalLikeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLikeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int likeId)
		{
			ActionResponse response = new ActionResponse(await this.LikeModelValidator.ValidateDeleteAsync(likeId));
			if (response.Success)
			{
				await this.LikeRepository.Delete(likeId);
			}

			return response;
		}

		public async Task<List<ApiLikeResponseModel>> ByLikerUserId(int likerUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Like> records = await this.LikeRepository.ByLikerUserId(likerUserId, limit, offset);

			return this.BolLikeMapper.MapBOToModel(this.DalLikeMapper.MapEFToBO(records));
		}

		public async Task<List<ApiLikeResponseModel>> ByTweetId(int tweetId, int limit = 0, int offset = int.MaxValue)
		{
			List<Like> records = await this.LikeRepository.ByTweetId(tweetId, limit, offset);

			return this.BolLikeMapper.MapBOToModel(this.DalLikeMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>75ddf5a67f517da33bda6467874911c4</Hash>
</Codenesium>*/