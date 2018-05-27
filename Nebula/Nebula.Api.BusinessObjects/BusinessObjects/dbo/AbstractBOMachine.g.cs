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
	public abstract class AbstractBOMachine: AbstractBOManager
	{
		private IMachineRepository machineRepository;
		private IApiMachineRequestModelValidator machineModelValidator;
		private IBOLMachineMapper machineMapper;
		private ILogger logger;

		public AbstractBOMachine(
			ILogger logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
			IBOLMachineMapper machineMapper)
			: base()

		{
			this.machineRepository = machineRepository;
			this.machineModelValidator = machineModelValidator;
			this.machineMapper = machineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.machineRepository.All(skip, take, orderClause);

			return this.machineMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiMachineResponseModel> Get(int id)
		{
			var record = await machineRepository.Get(id);

			return this.machineMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model)
		{
			CreateResponse<ApiMachineResponseModel> response = new CreateResponse<ApiMachineResponseModel>(await this.machineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.machineMapper.MapModelToDTO(default (int), model);
				var record = await this.machineRepository.Create(dto);

				response.SetRecord(this.machineMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiMachineRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.machineMapper.MapModelToDTO(id, model);
				await this.machineRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.machineRepository.Delete(id);
			}
			return response;
		}

		public async Task<ApiMachineResponseModel> GetMachineGuid(Guid machineGuid)
		{
			DTOMachine record = await this.machineRepository.GetMachineGuid(machineGuid);

			return this.machineMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>6f08ef29bd9052e2cee07316ec101663</Hash>
</Codenesium>*/