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

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOState: AbstractBOManager
	{
		private IStateRepository stateRepository;
		private IApiStateRequestModelValidator stateModelValidator;
		private IBOLStateMapper stateMapper;
		private ILogger logger;

		public AbstractBOState(
			ILogger logger,
			IStateRepository stateRepository,
			IApiStateRequestModelValidator stateModelValidator,
			IBOLStateMapper stateMapper)
			: base()

		{
			this.stateRepository = stateRepository;
			this.stateModelValidator = stateModelValidator;
			this.stateMapper = stateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.stateRepository.All(skip, take, orderClause);

			return this.stateMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiStateResponseModel> Get(int id)
		{
			var record = await stateRepository.Get(id);

			return this.stateMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiStateResponseModel>> Create(
			ApiStateRequestModel model)
		{
			CreateResponse<ApiStateResponseModel> response = new CreateResponse<ApiStateResponseModel>(await this.stateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.stateMapper.MapModelToDTO(default (int), model);
				var record = await this.stateRepository.Create(dto);

				response.SetRecord(this.stateMapper.MapDTOToModel(record));
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
				var dto = this.stateMapper.MapModelToDTO(id, model);
				await this.stateRepository.Update(id, dto);
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
    <Hash>f54c0c296cdb91b8031f8e5b3fb971e5</Hash>
</Codenesium>*/