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
	public abstract class AbstractTagService : AbstractService
	{
		protected ITagRepository TagRepository { get; private set; }

		protected IApiTagRequestModelValidator TagModelValidator { get; private set; }

		protected IBOLTagMapper BolTagMapper { get; private set; }

		protected IDALTagMapper DalTagMapper { get; private set; }

		private ILogger logger;

		public AbstractTagService(
			ILogger logger,
			ITagRepository tagRepository,
			IApiTagRequestModelValidator tagModelValidator,
			IBOLTagMapper bolTagMapper,
			IDALTagMapper dalTagMapper)
			: base()
		{
			this.TagRepository = tagRepository;
			this.TagModelValidator = tagModelValidator;
			this.BolTagMapper = bolTagMapper;
			this.DalTagMapper = dalTagMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTagResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TagRepository.All(limit, offset);

			return this.BolTagMapper.MapBOToModel(this.DalTagMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTagResponseModel> Get(int id)
		{
			var record = await this.TagRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTagMapper.MapBOToModel(this.DalTagMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTagResponseModel>> Create(
			ApiTagRequestModel model)
		{
			CreateResponse<ApiTagResponseModel> response = new CreateResponse<ApiTagResponseModel>(await this.TagModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTagMapper.MapModelToBO(default(int), model);
				var record = await this.TagRepository.Create(this.DalTagMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTagMapper.MapBOToModel(this.DalTagMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTagResponseModel>> Update(
			int id,
			ApiTagRequestModel model)
		{
			var validationResult = await this.TagModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTagMapper.MapModelToBO(id, model);
				await this.TagRepository.Update(this.DalTagMapper.MapBOToEF(bo));

				var record = await this.TagRepository.Get(id);

				return new UpdateResponse<ApiTagResponseModel>(this.BolTagMapper.MapBOToModel(this.DalTagMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTagResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TagModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TagRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>68d83b42c04e2d9b6a98064fc4fc8750</Hash>
</Codenesium>*/