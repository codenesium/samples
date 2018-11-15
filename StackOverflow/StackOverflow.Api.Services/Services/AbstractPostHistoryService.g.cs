using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostHistoryService : AbstractService
	{
		protected IPostHistoryRepository PostHistoryRepository { get; private set; }

		protected IApiPostHistoryServerRequestModelValidator PostHistoryModelValidator { get; private set; }

		protected IBOLPostHistoryMapper BolPostHistoryMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryService(
			ILogger logger,
			IPostHistoryRepository postHistoryRepository,
			IApiPostHistoryServerRequestModelValidator postHistoryModelValidator,
			IBOLPostHistoryMapper bolPostHistoryMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base()
		{
			this.PostHistoryRepository = postHistoryRepository;
			this.PostHistoryModelValidator = postHistoryModelValidator;
			this.BolPostHistoryMapper = bolPostHistoryMapper;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostHistoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostHistoryRepository.All(limit, offset);

			return this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostHistoryServerResponseModel> Get(int id)
		{
			var record = await this.PostHistoryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryServerResponseModel>> Create(
			ApiPostHistoryServerRequestModel model)
		{
			CreateResponse<ApiPostHistoryServerResponseModel> response = ValidationResponseFactory<ApiPostHistoryServerResponseModel>.CreateResponse(await this.PostHistoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPostHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.PostHistoryRepository.Create(this.DalPostHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryServerResponseModel>> Update(
			int id,
			ApiPostHistoryServerRequestModel model)
		{
			var validationResult = await this.PostHistoryModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostHistoryMapper.MapModelToBO(id, model);
				await this.PostHistoryRepository.Update(this.DalPostHistoryMapper.MapBOToEF(bo));

				var record = await this.PostHistoryRepository.Get(id);

				return ValidationResponseFactory<ApiPostHistoryServerResponseModel>.UpdateResponse(this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPostHistoryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostHistoryModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostHistoryRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fea3c9bc87a0353e7b80c391e2c73783</Hash>
</Codenesium>*/