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
		protected IStateRepository StateRepository { get; private set; }

		protected IApiStateRequestModelValidator StateModelValidator { get; private set; }

		protected IBOLStateMapper BolStateMapper { get; private set; }

		protected IDALStateMapper DalStateMapper { get; private set; }

		protected IBOLStudioMapper BolStudioMapper { get; private set; }

		protected IDALStudioMapper DalStudioMapper { get; private set; }

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
			this.StateRepository = stateRepository;
			this.StateModelValidator = stateModelValidator;
			this.BolStateMapper = bolStateMapper;
			this.DalStateMapper = dalStateMapper;
			this.BolStudioMapper = bolStudioMapper;
			this.DalStudioMapper = dalStudioMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StateRepository.All(limit, offset);

			return this.BolStateMapper.MapBOToModel(this.DalStateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStateResponseModel> Get(int id)
		{
			var record = await this.StateRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStateMapper.MapBOToModel(this.DalStateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStateResponseModel>> Create(
			ApiStateRequestModel model)
		{
			CreateResponse<ApiStateResponseModel> response = new CreateResponse<ApiStateResponseModel>(await this.StateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolStateMapper.MapModelToBO(default(int), model);
				var record = await this.StateRepository.Create(this.DalStateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolStateMapper.MapBOToModel(this.DalStateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStateResponseModel>> Update(
			int id,
			ApiStateRequestModel model)
		{
			var validationResult = await this.StateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStateMapper.MapModelToBO(id, model);
				await this.StateRepository.Update(this.DalStateMapper.MapBOToEF(bo));

				var record = await this.StateRepository.Get(id);

				return new UpdateResponse<ApiStateResponseModel>(this.BolStateMapper.MapBOToModel(this.DalStateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiStateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.StateModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.StateRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiStudioResponseModel>> Studios(int stateId, int limit = int.MaxValue, int offset = 0)
		{
			List<Studio> records = await this.StateRepository.Studios(stateId, limit, offset);

			return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1f0415ce82d99b4631f5c65b11a81e69</Hash>
</Codenesium>*/