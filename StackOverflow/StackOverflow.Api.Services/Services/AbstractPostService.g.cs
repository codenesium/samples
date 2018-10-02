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
	public abstract class AbstractPostService : AbstractService
	{
		protected IPostRepository PostRepository { get; private set; }

		protected IApiPostRequestModelValidator PostModelValidator { get; private set; }

		protected IBOLPostMapper BolPostMapper { get; private set; }

		protected IDALPostMapper DalPostMapper { get; private set; }

		private ILogger logger;

		public AbstractPostService(
			ILogger logger,
			IPostRepository postRepository,
			IApiPostRequestModelValidator postModelValidator,
			IBOLPostMapper bolPostMapper,
			IDALPostMapper dalPostMapper)
			: base()
		{
			this.PostRepository = postRepository;
			this.PostModelValidator = postModelValidator;
			this.BolPostMapper = bolPostMapper;
			this.DalPostMapper = dalPostMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostRepository.All(limit, offset);

			return this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostResponseModel> Get(int id)
		{
			var record = await this.PostRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostResponseModel>> Create(
			ApiPostRequestModel model)
		{
			CreateResponse<ApiPostResponseModel> response = new CreateResponse<ApiPostResponseModel>(await this.PostModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostMapper.MapModelToBO(default(int), model);
				var record = await this.PostRepository.Create(this.DalPostMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostResponseModel>> Update(
			int id,
			ApiPostRequestModel model)
		{
			var validationResult = await this.PostModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostMapper.MapModelToBO(id, model);
				await this.PostRepository.Update(this.DalPostMapper.MapBOToEF(bo));

				var record = await this.PostRepository.Get(id);

				return new UpdateResponse<ApiPostResponseModel>(this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiPostResponseModel>> ByOwnerUserId(int? ownerUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Post> records = await this.PostRepository.ByOwnerUserId(ownerUserId, limit, offset);

			return this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>767b6504b0f12daeac5e378f549efad6</Hash>
</Codenesium>*/