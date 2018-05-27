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

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOMachineRefTeam: AbstractBOManager
	{
		private IMachineRefTeamRepository machineRefTeamRepository;
		private IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator;
		private IBOLMachineRefTeamMapper machineRefTeamMapper;
		private ILogger logger;

		public AbstractBOMachineRefTeam(
			ILogger logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
			IBOLMachineRefTeamMapper machineRefTeamMapper)
			: base()

		{
			this.machineRefTeamRepository = machineRefTeamRepository;
			this.machineRefTeamModelValidator = machineRefTeamModelValidator;
			this.machineRefTeamMapper = machineRefTeamMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.machineRefTeamRepository.All(skip, take, orderClause);

			return this.machineRefTeamMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiMachineRefTeamResponseModel> Get(int id)
		{
			var record = await machineRefTeamRepository.Get(id);

			return this.machineRefTeamMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
			ApiMachineRefTeamRequestModel model)
		{
			CreateResponse<ApiMachineRefTeamResponseModel> response = new CreateResponse<ApiMachineRefTeamResponseModel>(await this.machineRefTeamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.machineRefTeamMapper.MapModelToDTO(default (int), model);
				var record = await this.machineRefTeamRepository.Create(dto);

				response.SetRecord(this.machineRefTeamMapper.MapDTOToModel(record));
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
				var dto = this.machineRefTeamMapper.MapModelToDTO(id, model);
				await this.machineRefTeamRepository.Update(id, dto);
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
    <Hash>486562811e74acfcd450696cddb3bd88</Hash>
</Codenesium>*/