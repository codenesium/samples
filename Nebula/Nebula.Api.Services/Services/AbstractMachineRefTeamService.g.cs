using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractMachineRefTeamService : AbstractService
	{
		private IMachineRefTeamRepository machineRefTeamRepository;

		private IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator;

		private IBOLMachineRefTeamMapper bolMachineRefTeamMapper;

		private IDALMachineRefTeamMapper dalMachineRefTeamMapper;

		private ILogger logger;

		public AbstractMachineRefTeamService(
			ILogger logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
			IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
			IDALMachineRefTeamMapper dalMachineRefTeamMapper)
			: base()
		{
			this.machineRefTeamRepository = machineRefTeamRepository;
			this.machineRefTeamModelValidator = machineRefTeamModelValidator;
			this.bolMachineRefTeamMapper = bolMachineRefTeamMapper;
			this.dalMachineRefTeamMapper = dalMachineRefTeamMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.machineRefTeamRepository.All(limit, offset);

			return this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachineRefTeamResponseModel> Get(int id)
		{
			var record = await this.machineRefTeamRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
			ApiMachineRefTeamRequestModel model)
		{
			CreateResponse<ApiMachineRefTeamResponseModel> response = new CreateResponse<ApiMachineRefTeamResponseModel>(await this.machineRefTeamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolMachineRefTeamMapper.MapModelToBO(default(int), model);
				var record = await this.machineRefTeamRepository.Create(this.dalMachineRefTeamMapper.MapBOToEF(bo));

				response.SetRecord(this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMachineRefTeamResponseModel>> Update(
			int id,
			ApiMachineRefTeamRequestModel model)
		{
			var validationResult = await this.machineRefTeamModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolMachineRefTeamMapper.MapModelToBO(id, model);
				await this.machineRefTeamRepository.Update(this.dalMachineRefTeamMapper.MapBOToEF(bo));

				var record = await this.machineRefTeamRepository.Get(id);

				return new UpdateResponse<ApiMachineRefTeamResponseModel>(this.bolMachineRefTeamMapper.MapBOToModel(this.dalMachineRefTeamMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiMachineRefTeamResponseModel>(validationResult);
			}
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
    <Hash>b67ee38c0366ccea5d73e540236393f3</Hash>
</Codenesium>*/