using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostService : AbstractService
	{
		protected IPostRepository PostRepository { get; private set; }

		protected IApiPostServerRequestModelValidator PostModelValidator { get; private set; }

		protected IBOLPostMapper BolPostMapper { get; private set; }

		protected IDALPostMapper DalPostMapper { get; private set; }

		private ILogger logger;

		public AbstractPostService(
			ILogger logger,
			IPostRepository postRepository,
			IApiPostServerRequestModelValidator postModelValidator,
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

		public virtual async Task<List<ApiPostServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostRepository.All(limit, offset);

			return this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiPostServerResponseModel>> Create(
			ApiPostServerRequestModel model)
		{
			CreateResponse<ApiPostServerResponseModel> response = ValidationResponseFactory<ApiPostServerResponseModel>.CreateResponse(await this.PostModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPostMapper.MapModelToBO(default(int), model);
				var record = await this.PostRepository.Create(this.DalPostMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostServerResponseModel>> Update(
			int id,
			ApiPostServerRequestModel model)
		{
			var validationResult = await this.PostModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostMapper.MapModelToBO(id, model);
				await this.PostRepository.Update(this.DalPostMapper.MapBOToEF(bo));

				var record = await this.PostRepository.Get(id);

				return ValidationResponseFactory<ApiPostServerResponseModel>.UpdateResponse(this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPostServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPostServerResponseModel>> ByOwnerUserId(int? ownerUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Post> records = await this.PostRepository.ByOwnerUserId(ownerUserId, limit, offset);

			return this.BolPostMapper.MapBOToModel(this.DalPostMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>14b8fe45abbee567c526920a99b7a6f5</Hash>
</Codenesium>*/