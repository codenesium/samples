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
		protected IMachineRefTeamRepository MachineRefTeamRepository { get; private set; }

		protected IApiMachineRefTeamRequestModelValidator MachineRefTeamModelValidator { get; private set; }

		protected IBOLMachineRefTeamMapper BolMachineRefTeamMapper { get; private set; }

		protected IDALMachineRefTeamMapper DalMachineRefTeamMapper { get; private set; }

		private ILogger logger;

		public AbstractMachineRefTeamService(
			ILogger logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
			IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
			IDALMachineRefTeamMapper dalMachineRefTeamMapper)
			: base()
		{
			this.MachineRefTeamRepository = machineRefTeamRepository;
			this.MachineRefTeamModelValidator = machineRefTeamModelValidator;
			this.BolMachineRefTeamMapper = bolMachineRefTeamMapper;
			this.DalMachineRefTeamMapper = dalMachineRefTeamMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachineRefTeamResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MachineRefTeamRepository.All(limit, offset);

			return this.BolMachineRefTeamMapper.MapBOToModel(this.DalMachineRefTeamMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachineRefTeamResponseModel> Get(int id)
		{
			var record = await this.MachineRefTeamRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMachineRefTeamMapper.MapBOToModel(this.DalMachineRefTeamMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
			ApiMachineRefTeamRequestModel model)
		{
			CreateResponse<ApiMachineRefTeamResponseModel> response = new CreateResponse<ApiMachineRefTeamResponseModel>(await this.MachineRefTeamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolMachineRefTeamMapper.MapModelToBO(default(int), model);
				var record = await this.MachineRefTeamRepository.Create(this.DalMachineRefTeamMapper.MapBOToEF(bo));

				response.SetRecord(this.BolMachineRefTeamMapper.MapBOToModel(this.DalMachineRefTeamMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMachineRefTeamResponseModel>> Update(
			int id,
			ApiMachineRefTeamRequestModel model)
		{
			var validationResult = await this.MachineRefTeamModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMachineRefTeamMapper.MapModelToBO(id, model);
				await this.MachineRefTeamRepository.Update(this.DalMachineRefTeamMapper.MapBOToEF(bo));

				var record = await this.MachineRefTeamRepository.Get(id);

				return new UpdateResponse<ApiMachineRefTeamResponseModel>(this.BolMachineRefTeamMapper.MapBOToModel(this.DalMachineRefTeamMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiMachineRefTeamResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.MachineRefTeamModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.MachineRefTeamRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f43075bbf040e74071c204c913536168</Hash>
</Codenesium>*/