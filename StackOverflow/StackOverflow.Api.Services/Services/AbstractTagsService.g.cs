using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractTagsService : AbstractService
	{
		protected ITagsRepository TagsRepository { get; private set; }

		protected IApiTagsRequestModelValidator TagsModelValidator { get; private set; }

		protected IBOLTagsMapper BolTagsMapper { get; private set; }

		protected IDALTagsMapper DalTagsMapper { get; private set; }

		private ILogger logger;

		public AbstractTagsService(
			ILogger logger,
			ITagsRepository tagsRepository,
			IApiTagsRequestModelValidator tagsModelValidator,
			IBOLTagsMapper bolTagsMapper,
			IDALTagsMapper dalTagsMapper)
			: base()
		{
			this.TagsRepository = tagsRepository;
			this.TagsModelValidator = tagsModelValidator;
			this.BolTagsMapper = bolTagsMapper;
			this.DalTagsMapper = dalTagsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTagsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TagsRepository.All(limit, offset);

			return this.BolTagsMapper.MapBOToModel(this.DalTagsMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTagsResponseModel> Get(int id)
		{
			var record = await this.TagsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTagsMapper.MapBOToModel(this.DalTagsMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTagsResponseModel>> Create(
			ApiTagsRequestModel model)
		{
			CreateResponse<ApiTagsResponseModel> response = new CreateResponse<ApiTagsResponseModel>(await this.TagsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTagsMapper.MapModelToBO(default(int), model);
				var record = await this.TagsRepository.Create(this.DalTagsMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTagsMapper.MapBOToModel(this.DalTagsMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTagsResponseModel>> Update(
			int id,
			ApiTagsRequestModel model)
		{
			var validationResult = await this.TagsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTagsMapper.MapModelToBO(id, model);
				await this.TagsRepository.Update(this.DalTagsMapper.MapBOToEF(bo));

				var record = await this.TagsRepository.Get(id);

				return new UpdateResponse<ApiTagsResponseModel>(this.BolTagsMapper.MapBOToModel(this.DalTagsMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTagsResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TagsModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TagsRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>67e643257a5e0a9b14bafedf644b69fe</Hash>
</Codenesium>*/