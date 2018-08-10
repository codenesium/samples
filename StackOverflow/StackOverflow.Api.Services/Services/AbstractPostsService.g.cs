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
	public abstract class AbstractPostsService : AbstractService
	{
		protected IPostsRepository PostsRepository { get; private set; }

		protected IApiPostsRequestModelValidator PostsModelValidator { get; private set; }

		protected IBOLPostsMapper BolPostsMapper { get; private set; }

		protected IDALPostsMapper DalPostsMapper { get; private set; }

		private ILogger logger;

		public AbstractPostsService(
			ILogger logger,
			IPostsRepository postsRepository,
			IApiPostsRequestModelValidator postsModelValidator,
			IBOLPostsMapper bolPostsMapper,
			IDALPostsMapper dalPostsMapper)
			: base()
		{
			this.PostsRepository = postsRepository;
			this.PostsModelValidator = postsModelValidator;
			this.BolPostsMapper = bolPostsMapper;
			this.DalPostsMapper = dalPostsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostsRepository.All(limit, offset);

			return this.BolPostsMapper.MapBOToModel(this.DalPostsMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostsResponseModel> Get(int id)
		{
			var record = await this.PostsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostsMapper.MapBOToModel(this.DalPostsMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostsResponseModel>> Create(
			ApiPostsRequestModel model)
		{
			CreateResponse<ApiPostsResponseModel> response = new CreateResponse<ApiPostsResponseModel>(await this.PostsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostsMapper.MapModelToBO(default(int), model);
				var record = await this.PostsRepository.Create(this.DalPostsMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostsMapper.MapBOToModel(this.DalPostsMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostsResponseModel>> Update(
			int id,
			ApiPostsRequestModel model)
		{
			var validationResult = await this.PostsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostsMapper.MapModelToBO(id, model);
				await this.PostsRepository.Update(this.DalPostsMapper.MapBOToEF(bo));

				var record = await this.PostsRepository.Get(id);

				return new UpdateResponse<ApiPostsResponseModel>(this.BolPostsMapper.MapBOToModel(this.DalPostsMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostsResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostsModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostsRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e13c00fed19e39bf0537da8354b64f59</Hash>
</Codenesium>*/