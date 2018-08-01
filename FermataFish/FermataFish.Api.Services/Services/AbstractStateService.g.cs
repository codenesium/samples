using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractStateService : AbstractService
	{
		private IStateRepository stateRepository;

		private IApiStateRequestModelValidator stateModelValidator;

		private IBOLStateMapper bolStateMapper;

		private IDALStateMapper dalStateMapper;

		private IBOLStudioMapper bolStudioMapper;

		private IDALStudioMapper dalStudioMapper;

		private ILogger logger;

		public AbstractStateService(
			ILogger logger,
			IStateRepository stateRepository,
			IApiStateRequestModelValidator stateModelValidator,
			IBOLStateMapper bolStateMapper,
			IDALStateMapper dalStateMapper,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper)
			: base()
		{
			this.stateRepository = stateRepository;
			this.stateModelValidator = stateModelValidator;
			this.bolStateMapper = bolStateMapper;
			this.dalStateMapper = dalStateMapper;
			this.bolStudioMapper = bolStudioMapper;
			this.dalStudioMapper = dalStudioMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.stateRepository.All(limit, offset);

			return this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStateResponseModel> Get(int id)
		{
			var record = await this.stateRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStateResponseModel>> Create(
			ApiStateRequestModel model)
		{
			CreateResponse<ApiStateResponseModel> response = new CreateResponse<ApiStateResponseModel>(await this.stateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolStateMapper.MapModelToBO(default(int), model);
				var record = await this.stateRepository.Create(this.dalStateMapper.MapBOToEF(bo));

				response.SetRecord(this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStateResponseModel>> Update(
			int id,
			ApiStateRequestModel model)
		{
			var validationResult = await this.stateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolStateMapper.MapModelToBO(id, model);
				await this.stateRepository.Update(this.dalStateMapper.MapBOToEF(bo));

				var record = await this.stateRepository.Get(id);

				return new UpdateResponse<ApiStateResponseModel>(this.bolStateMapper.MapBOToModel(this.dalStateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiStateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.stateModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.stateRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiStudioResponseModel>> Studios(int stateId, int limit = int.MaxValue, int offset = 0)
		{
			List<Studio> records = await this.stateRepository.Studios(stateId, limit, offset);

			return this.bolStudioMapper.MapBOToModel(this.dalStudioMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>9b4d05c544762360af8d664f5204cb46</Hash>
</Codenesium>*/