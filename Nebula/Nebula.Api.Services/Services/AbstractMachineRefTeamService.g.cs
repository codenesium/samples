using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractMachineRefTeamService: AbstractService
	{
		private IMachineRefTeamRepository machineRefTeamRepository;
		private IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator;
		private IBOLMachineRefTeamMapper BOLMachineRefTeamMapper;
		private IDALMachineRefTeamMapper DALMachineRefTeamMapper;
		private ILogger logger;

		public AbstractMachineRefTeamService(
			ILogger logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
			IBOLMachineRefTeamMapper bolmachineRefTeamMapper,
			IDALMachineRefTeamMapper dalmachineRefTeamMapper)
			: base()

		{
			this.machineRefTeamRepository = machineRefTeamRepository;
			this.machineRefTeamModelValidator = machineRefTeamModelValidator;
			this.BOLMachineRefTeamMapper = bolmachineRefTeamMapper;
			this.DALMachineRefTeamMapper = dalmachineRefTeamMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.machineRefTeamRepository.All(skip, take, orderClause);

			return this.BOLMachineRefTeamMapper.MapBOToModel(this.DALMachineRefTeamMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachineRefTeamResponseModel> Get(int id)
		{
			var record = await machineRefTeamRepository.Get(id);

			return this.BOLMachineRefTeamMapper.MapBOToModel(this.DALMachineRefTeamMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
			ApiMachineRefTeamRequestModel model)
		{
			CreateResponse<ApiMachineRefTeamResponseModel> response = new CreateResponse<ApiMachineRefTeamResponseModel>(await this.machineRefTeamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLMachineRefTeamMapper.MapModelToBO(default (int), model);
				var record = await this.machineRefTeamRepository.Create(this.DALMachineRefTeamMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLMachineRefTeamMapper.MapBOToModel(this.DALMachineRefTeamMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiMachineRefTeamRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.machineRefTeamModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLMachineRefTeamMapper.MapModelToBO(id, model);
				await this.machineRefTeamRepository.Update(this.DALMachineRefTeamMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.machineRefTeamModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.machineRefTeamRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>06d624941c84414aefea74391f682ebf</Hash>
</Codenesium>*/