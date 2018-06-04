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
		private IBOLMachineMapper BOLMachineMapper;
		private IDALMachineMapper DALMachineMapper;
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
			this.BOLMachineMapper = bolmachineMapper;
			this.DALMachineMapper = dalmachineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.machineRepository.All(skip, take, orderClause);

			return this.BOLMachineMapper.MapBOToModel(this.DALMachineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachineResponseModel> Get(int id)
		{
			var record = await machineRepository.Get(id);

			return this.BOLMachineMapper.MapBOToModel(this.DALMachineMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model)
		{
			CreateResponse<ApiMachineResponseModel> response = new CreateResponse<ApiMachineResponseModel>(await this.machineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLMachineMapper.MapModelToBO(default (int), model);
				var record = await this.machineRepository.Create(this.DALMachineMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLMachineMapper.MapBOToModel(this.DALMachineMapper.MapEFToBO(record)));
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
				var bo = this.BOLMachineMapper.MapModelToBO(id, model);
				await this.machineRepository.Update(this.DALMachineMapper.MapBOToEF(bo));
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
    <Hash>ae749c957680a600221f50c59602325b</Hash>
</Codenesium>*/