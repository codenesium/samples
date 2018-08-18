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
	public abstract class AbstractFeedService : AbstractService
	{
		protected IFeedRepository FeedRepository { get; private set; }

		protected IApiFeedRequestModelValidator FeedModelValidator { get; private set; }

		protected IBOLFeedMapper BolFeedMapper { get; private set; }

		protected IDALFeedMapper DalFeedMapper { get; private set; }

		private ILogger logger;

		public AbstractFeedService(
			ILogger logger,
			IFeedRepository feedRepository,
			IApiFeedRequestModelValidator feedModelValidator,
			IBOLFeedMapper bolFeedMapper,
			IDALFeedMapper dalFeedMapper)
			: base()
		{
			this.FeedRepository = feedRepository;
			this.FeedModelValidator = feedModelValidator;
			this.BolFeedMapper = bolFeedMapper;
			this.DalFeedMapper = dalFeedMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFeedResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FeedRepository.All(limit, offset);

			return this.BolFeedMapper.MapBOToModel(this.DalFeedMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFeedResponseModel> Get(string id)
		{
			var record = await this.FeedRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFeedMapper.MapBOToModel(this.DalFeedMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFeedResponseModel>> Create(
			ApiFeedRequestModel model)
		{
			CreateResponse<ApiFeedResponseModel> response = new CreateResponse<ApiFeedResponseModel>(await this.FeedModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolFeedMapper.MapModelToBO(default(string), model);
				var record = await this.FeedRepository.Create(this.DalFeedMapper.MapBOToEF(bo));

				response.SetRecord(this.BolFeedMapper.MapBOToModel(this.DalFeedMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFeedResponseModel>> Update(
			string id,
			ApiFeedRequestModel model)
		{
			var validationResult = await this.FeedModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolFeedMapper.MapModelToBO(id, model);
				await this.FeedRepository.Update(this.DalFeedMapper.MapBOToEF(bo));

				var record = await this.FeedRepository.Get(id);

				return new UpdateResponse<ApiFeedResponseModel>(this.BolFeedMapper.MapBOToModel(this.DalFeedMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiFeedResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.FeedModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.FeedRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiFeedResponseModel> ByName(string name)
		{
			Feed record = await this.FeedRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFeedMapper.MapBOToModel(this.DalFeedMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>401365514ce07d41d5c762f17d2891c7</Hash>
</Codenesium>*/