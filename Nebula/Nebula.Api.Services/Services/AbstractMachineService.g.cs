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
	public abstract class AbstractMachineService: AbstractService
	{
		private IMachineRepository machineRepository;
		private IApiMachineRequestModelValidator machineModelValidator;
		private IBOLMachineMapper bolMachineMapper;
		private IDALMachineMapper dalMachineMapper;
		private ILogger logger;

		public AbstractMachineService(
			ILogger logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
			IBOLMachineMapper bolmachineMapper,
			IDALMachineMapper dalmachineMapper)
			: base()

		{
			this.machineRepository = machineRepository;
			this.machineModelValidator = machineModelValidator;
			this.bolMachineMapper = bolmachineMapper;
			this.dalMachineMapper = dalmachineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.machineRepository.All(skip, take, orderClause);

			return this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachineResponseModel> Get(int id)
		{
			var record = await machineRepository.Get(id);

			return this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model)
		{
			CreateResponse<ApiMachineResponseModel> response = new CreateResponse<ApiMachineResponseModel>(await this.machineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolMachineMapper.MapModelToBO(default (int), model);
				var record = await this.machineRepository.Create(this.dalMachineMapper.MapBOToEF(bo));

				response.SetRecord(this.bolMachineMapper.MapBOToModel(this.dalMachineMapper.MapEFToBO(record)));
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
				var bo = this.bolMachineMapper.MapModelToBO(id, model);
				await this.machineRepository.Update(this.dalMachineMapper.MapBOToEF(bo));
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
	}
}

/*<Codenesium>
    <Hash>c93e91208a7a794f162b6ea70b5e9cbe</Hash>
</Codenesium>*/