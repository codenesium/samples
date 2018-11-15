using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractTagService : AbstractService
	{
		protected ITagRepository TagRepository { get; private set; }

		protected IApiTagServerRequestModelValidator TagModelValidator { get; private set; }

		protected IBOLTagMapper BolTagMapper { get; private set; }

		protected IDALTagMapper DalTagMapper { get; private set; }

		private ILogger logger;

		public AbstractTagService(
			ILogger logger,
			ITagRepository tagRepository,
			IApiTagServerRequestModelValidator tagModelValidator,
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

		public virtual async Task<List<ApiTagServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TagRepository.All(limit, offset);

			return this.BolTagMapper.MapBOToModel(this.DalTagMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTagServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiTagServerResponseModel>> Create(
			ApiTagServerRequestModel model)
		{
			CreateResponse<ApiTagServerResponseModel> response = ValidationResponseFactory<ApiTagServerResponseModel>.CreateResponse(await this.TagModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTagMapper.MapModelToBO(default(int), model);
				var record = await this.TagRepository.Create(this.DalTagMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTagMapper.MapBOToModel(this.DalTagMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTagServerResponseModel>> Update(
			int id,
			ApiTagServerRequestModel model)
		{
			var validationResult = await this.TagModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTagMapper.MapModelToBO(id, model);
				await this.TagRepository.Update(this.DalTagMapper.MapBOToEF(bo));

				var record = await this.TagRepository.Get(id);

				return ValidationResponseFactory<ApiTagServerResponseModel>.UpdateResponse(this.BolTagMapper.MapBOToModel(this.DalTagMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiTagServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TagModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TagRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e23fc6f088f7ca8a692772fd54447196</Hash>
</Codenesium>*/