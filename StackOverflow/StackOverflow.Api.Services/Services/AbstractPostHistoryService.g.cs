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
	public abstract class AbstractPostHistoryService : AbstractService
	{
		protected IPostHistoryRepository PostHistoryRepository { get; private set; }

		protected IApiPostHistoryRequestModelValidator PostHistoryModelValidator { get; private set; }

		protected IBOLPostHistoryMapper BolPostHistoryMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryService(
			ILogger logger,
			IPostHistoryRepository postHistoryRepository,
			IApiPostHistoryRequestModelValidator postHistoryModelValidator,
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

		public virtual async Task<List<ApiPostHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostHistoryRepository.All(limit, offset);

			return this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostHistoryResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiPostHistoryResponseModel>> Create(
			ApiPostHistoryRequestModel model)
		{
			CreateResponse<ApiPostHistoryResponseModel> response = new CreateResponse<ApiPostHistoryResponseModel>(await this.PostHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.PostHistoryRepository.Create(this.DalPostHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryResponseModel>> Update(
			int id,
			ApiPostHistoryRequestModel model)
		{
			var validationResult = await this.PostHistoryModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostHistoryMapper.MapModelToBO(id, model);
				await this.PostHistoryRepository.Update(this.DalPostHistoryMapper.MapBOToEF(bo));

				var record = await this.PostHistoryRepository.Get(id);

				return new UpdateResponse<ApiPostHistoryResponseModel>(this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostHistoryModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostHistoryRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>538190c3cd77c6bf57075ee3dfdde9cc</Hash>
</Codenesium>*/