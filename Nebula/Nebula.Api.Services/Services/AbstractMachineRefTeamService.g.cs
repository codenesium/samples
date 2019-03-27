using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractMachineRefTeamService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IMachineRefTeamRepository MachineRefTeamRepository { get; private set; }

		protected IApiMachineRefTeamServerRequestModelValidator MachineRefTeamModelValidator { get; private set; }

		protected IDALMachineRefTeamMapper DalMachineRefTeamMapper { get; private set; }

		private ILogger logger;

		public AbstractMachineRefTeamService(
			ILogger logger,
			MediatR.IMediator mediator,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamServerRequestModelValidator machineRefTeamModelValidator,
			IDALMachineRefTeamMapper dalMachineRefTeamMapper)
			: base()
		{
			this.MachineRefTeamRepository = machineRefTeamRepository;
			this.MachineRefTeamModelValidator = machineRefTeamModelValidator;
			this.DalMachineRefTeamMapper = dalMachineRefTeamMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiMachineRefTeamServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<MachineRefTeam> records = await this.MachineRefTeamRepository.All(limit, offset, query);

			return this.DalMachineRefTeamMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiMachineRefTeamServerResponseModel> Get(int id)
		{
			MachineRefTeam record = await this.MachineRefTeamRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalMachineRefTeamMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiMachineRefTeamServerResponseModel>> Create(
			ApiMachineRefTeamServerRequestModel model)
		{
			CreateResponse<ApiMachineRefTeamServerResponseModel> response = ValidationResponseFactory<ApiMachineRefTeamServerResponseModel>.CreateResponse(await this.MachineRefTeamModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				MachineRefTeam record = this.DalMachineRefTeamMapper.MapModelToEntity(default(int), model);
				record = await this.MachineRefTeamRepository.Create(record);

				response.SetRecord(this.DalMachineRefTeamMapper.MapEntityToModel(record));
				await this.mediator.Publish(new MachineRefTeamCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMachineRefTeamServerResponseModel>> Update(
			int id,
			ApiMachineRefTeamServerRequestModel model)
		{
			var validationResult = await this.MachineRefTeamModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				MachineRefTeam record = this.DalMachineRefTeamMapper.MapModelToEntity(id, model);
				await this.MachineRefTeamRepository.Update(record);

				record = await this.MachineRefTeamRepository.Get(id);

				ApiMachineRefTeamServerResponseModel apiModel = this.DalMachineRefTeamMapper.MapEntityToModel(record);
				await this.mediator.Publish(new MachineRefTeamUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiMachineRefTeamServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiMachineRefTeamServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.MachineRefTeamModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.MachineRefTeamRepository.Delete(id);

				await this.mediator.Publish(new MachineRefTeamDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ebc75773753301fce893554ca268f88c</Hash>
</Codenesium>*/