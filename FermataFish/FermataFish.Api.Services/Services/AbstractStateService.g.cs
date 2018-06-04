using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractStateService: AbstractService
	{
		private IStateRepository stateRepository;
		private IApiStateRequestModelValidator stateModelValidator;
		private IBOLStateMapper BOLStateMapper;
		private IDALStateMapper DALStateMapper;
		private ILogger logger;

		public AbstractStateService(
			ILogger logger,
			IStateRepository stateRepository,
			IApiStateRequestModelValidator stateModelValidator,
			IBOLStateMapper bolstateMapper,
			IDALStateMapper dalstateMapper)
			: base()

		{
			this.stateRepository = stateRepository;
			this.stateModelValidator = stateModelValidator;
			this.BOLStateMapper = bolstateMapper;
			this.DALStateMapper = dalstateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.stateRepository.All(skip, take, orderClause);

			return this.BOLStateMapper.MapBOToModel(this.DALStateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStateResponseModel> Get(int id)
		{
			var record = await stateRepository.Get(id);

			return this.BOLStateMapper.MapBOToModel(this.DALStateMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiStateResponseModel>> Create(
			ApiStateRequestModel model)
		{
			CreateResponse<ApiStateResponseModel> response = new CreateResponse<ApiStateResponseModel>(await this.stateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLStateMapper.MapModelToBO(default (int), model);
				var record = await this.stateRepository.Create(this.DALStateMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLStateMapper.MapBOToModel(this.DALStateMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStateRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.stateModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLStateMapper.MapModelToBO(id, model);
				await this.stateRepository.Update(this.DALStateMapper.MapBOToEF(bo));
			}

			return response;
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
	}
}

/*<Codenesium>
    <Hash>09971cf420d05cfb5fd81d9df7b0d38f</Hash>
</Codenesium>*/