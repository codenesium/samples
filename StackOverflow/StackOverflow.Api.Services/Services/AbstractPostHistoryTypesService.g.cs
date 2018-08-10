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
	public abstract class AbstractPostHistoryTypesService : AbstractService
	{
		protected IPostHistoryTypesRepository PostHistoryTypesRepository { get; private set; }

		protected IApiPostHistoryTypesRequestModelValidator PostHistoryTypesModelValidator { get; private set; }

		protected IBOLPostHistoryTypesMapper BolPostHistoryTypesMapper { get; private set; }

		protected IDALPostHistoryTypesMapper DalPostHistoryTypesMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryTypesService(
			ILogger logger,
			IPostHistoryTypesRepository postHistoryTypesRepository,
			IApiPostHistoryTypesRequestModelValidator postHistoryTypesModelValidator,
			IBOLPostHistoryTypesMapper bolPostHistoryTypesMapper,
			IDALPostHistoryTypesMapper dalPostHistoryTypesMapper)
			: base()
		{
			this.PostHistoryTypesRepository = postHistoryTypesRepository;
			this.PostHistoryTypesModelValidator = postHistoryTypesModelValidator;
			this.BolPostHistoryTypesMapper = bolPostHistoryTypesMapper;
			this.DalPostHistoryTypesMapper = dalPostHistoryTypesMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostHistoryTypesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostHistoryTypesRepository.All(limit, offset);

			return this.BolPostHistoryTypesMapper.MapBOToModel(this.DalPostHistoryTypesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostHistoryTypesResponseModel> Get(int id)
		{
			var record = await this.PostHistoryTypesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostHistoryTypesMapper.MapBOToModel(this.DalPostHistoryTypesMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryTypesResponseModel>> Create(
			ApiPostHistoryTypesRequestModel model)
		{
			CreateResponse<ApiPostHistoryTypesResponseModel> response = new CreateResponse<ApiPostHistoryTypesResponseModel>(await this.PostHistoryTypesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostHistoryTypesMapper.MapModelToBO(default(int), model);
				var record = await this.PostHistoryTypesRepository.Create(this.DalPostHistoryTypesMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostHistoryTypesMapper.MapBOToModel(this.DalPostHistoryTypesMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryTypesResponseModel>> Update(
			int id,
			ApiPostHistoryTypesRequestModel model)
		{
			var validationResult = await this.PostHistoryTypesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostHistoryTypesMapper.MapModelToBO(id, model);
				await this.PostHistoryTypesRepository.Update(this.DalPostHistoryTypesMapper.MapBOToEF(bo));

				var record = await this.PostHistoryTypesRepository.Get(id);

				return new UpdateResponse<ApiPostHistoryTypesResponseModel>(this.BolPostHistoryTypesMapper.MapBOToModel(this.DalPostHistoryTypesMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostHistoryTypesResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostHistoryTypesModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostHistoryTypesRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0feb74ffc1258f3f5ce1366498effc95</Hash>
</Codenesium>*/