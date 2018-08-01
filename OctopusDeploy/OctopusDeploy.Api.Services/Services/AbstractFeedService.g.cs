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
		private IFeedRepository feedRepository;

		private IApiFeedRequestModelValidator feedModelValidator;

		private IBOLFeedMapper bolFeedMapper;

		private IDALFeedMapper dalFeedMapper;

		private ILogger logger;

		public AbstractFeedService(
			ILogger logger,
			IFeedRepository feedRepository,
			IApiFeedRequestModelValidator feedModelValidator,
			IBOLFeedMapper bolFeedMapper,
			IDALFeedMapper dalFeedMapper)
			: base()
		{
			this.feedRepository = feedRepository;
			this.feedModelValidator = feedModelValidator;
			this.bolFeedMapper = bolFeedMapper;
			this.dalFeedMapper = dalFeedMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFeedResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.feedRepository.All(limit, offset);

			return this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFeedResponseModel> Get(string id)
		{
			var record = await this.feedRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFeedResponseModel>> Create(
			ApiFeedRequestModel model)
		{
			CreateResponse<ApiFeedResponseModel> response = new CreateResponse<ApiFeedResponseModel>(await this.feedModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolFeedMapper.MapModelToBO(default(string), model);
				var record = await this.feedRepository.Create(this.dalFeedMapper.MapBOToEF(bo));

				response.SetRecord(this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFeedResponseModel>> Update(
			string id,
			ApiFeedRequestModel model)
		{
			var validationResult = await this.feedModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolFeedMapper.MapModelToBO(id, model);
				await this.feedRepository.Update(this.dalFeedMapper.MapBOToEF(bo));

				var record = await this.feedRepository.Get(id);

				return new UpdateResponse<ApiFeedResponseModel>(this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiFeedResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.feedModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.feedRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiFeedResponseModel> ByName(string name)
		{
			Feed record = await this.feedRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolFeedMapper.MapBOToModel(this.dalFeedMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>91324c896181283b5d70781fa2b0cf0d</Hash>
</Codenesium>*/