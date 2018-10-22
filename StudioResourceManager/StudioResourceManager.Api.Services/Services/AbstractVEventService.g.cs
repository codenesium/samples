using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractVEventService : AbstractService
	{
		protected IVEventRepository VEventRepository { get; private set; }

		protected IApiVEventRequestModelValidator VEventModelValidator { get; private set; }

		protected IBOLVEventMapper BolVEventMapper { get; private set; }

		protected IDALVEventMapper DalVEventMapper { get; private set; }

		private ILogger logger;

		public AbstractVEventService(
			ILogger logger,
			IVEventRepository vEventRepository,
			IApiVEventRequestModelValidator vEventModelValidator,
			IBOLVEventMapper bolVEventMapper,
			IDALVEventMapper dalVEventMapper)
			: base()
		{
			this.VEventRepository = vEventRepository;
			this.VEventModelValidator = vEventModelValidator;
			this.BolVEventMapper = bolVEventMapper;
			this.DalVEventMapper = dalVEventMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVEventResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VEventRepository.All(limit, offset);

			return this.BolVEventMapper.MapBOToModel(this.DalVEventMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVEventResponseModel> Get(int id)
		{
			var record = await this.VEventRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVEventMapper.MapBOToModel(this.DalVEventMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVEventResponseModel>> Create(
			ApiVEventRequestModel model)
		{
			CreateResponse<ApiVEventResponseModel> response = new CreateResponse<ApiVEventResponseModel>(await this.VEventModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVEventMapper.MapModelToBO(default(int), model);
				var record = await this.VEventRepository.Create(this.DalVEventMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVEventMapper.MapBOToModel(this.DalVEventMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVEventResponseModel>> Update(
			int id,
			ApiVEventRequestModel model)
		{
			var validationResult = await this.VEventModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVEventMapper.MapModelToBO(id, model);
				await this.VEventRepository.Update(this.DalVEventMapper.MapBOToEF(bo));

				var record = await this.VEventRepository.Get(id);

				return new UpdateResponse<ApiVEventResponseModel>(this.BolVEventMapper.MapBOToModel(this.DalVEventMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVEventResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.VEventModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.VEventRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a218886ef11a1e1c81a1dae59aa11e57</Hash>
</Codenesium>*/