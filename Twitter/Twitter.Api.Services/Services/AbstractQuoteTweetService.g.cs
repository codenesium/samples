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
	public abstract class AbstractQuoteTweetService : AbstractService
	{
		protected IQuoteTweetRepository QuoteTweetRepository { get; private set; }

		protected IApiQuoteTweetRequestModelValidator QuoteTweetModelValidator { get; private set; }

		protected IBOLQuoteTweetMapper BolQuoteTweetMapper { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		private ILogger logger;

		public AbstractQuoteTweetService(
			ILogger logger,
			IQuoteTweetRepository quoteTweetRepository,
			IApiQuoteTweetRequestModelValidator quoteTweetModelValidator,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper)
			: base()
		{
			this.QuoteTweetRepository = quoteTweetRepository;
			this.QuoteTweetModelValidator = quoteTweetModelValidator;
			this.BolQuoteTweetMapper = bolQuoteTweetMapper;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiQuoteTweetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.QuoteTweetRepository.All(limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiQuoteTweetResponseModel> Get(int quoteTweetId)
		{
			var record = await this.QuoteTweetRepository.Get(quoteTweetId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiQuoteTweetResponseModel>> Create(
			ApiQuoteTweetRequestModel model)
		{
			CreateResponse<ApiQuoteTweetResponseModel> response = new CreateResponse<ApiQuoteTweetResponseModel>(await this.QuoteTweetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolQuoteTweetMapper.MapModelToBO(default(int), model);
				var record = await this.QuoteTweetRepository.Create(this.DalQuoteTweetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiQuoteTweetResponseModel>> Update(
			int quoteTweetId,
			ApiQuoteTweetRequestModel model)
		{
			var validationResult = await this.QuoteTweetModelValidator.ValidateUpdateAsync(quoteTweetId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolQuoteTweetMapper.MapModelToBO(quoteTweetId, model);
				await this.QuoteTweetRepository.Update(this.DalQuoteTweetMapper.MapBOToEF(bo));

				var record = await this.QuoteTweetRepository.Get(quoteTweetId);

				return new UpdateResponse<ApiQuoteTweetResponseModel>(this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiQuoteTweetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int quoteTweetId)
		{
			ActionResponse response = new ActionResponse(await this.QuoteTweetModelValidator.ValidateDeleteAsync(quoteTweetId));
			if (response.Success)
			{
				await this.QuoteTweetRepository.Delete(quoteTweetId);
			}

			return response;
		}

		public async Task<List<ApiQuoteTweetResponseModel>> ByRetweeterUserId(int retweeterUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<QuoteTweet> records = await this.QuoteTweetRepository.ByRetweeterUserId(retweeterUserId, limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}

		public async Task<List<ApiQuoteTweetResponseModel>> BySourceTweetId(int sourceTweetId, int limit = 0, int offset = int.MaxValue)
		{
			List<QuoteTweet> records = await this.QuoteTweetRepository.BySourceTweetId(sourceTweetId, limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ee7f1e0f0f83932384cec9b3d5bb4445</Hash>
</Codenesium>*/