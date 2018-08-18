using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractMachineService : AbstractService
	{
		protected IMachineRepository MachineRepository { get; private set; }

		protected IApiMachineRequestModelValidator MachineModelValidator { get; private set; }

		protected IBOLMachineMapper BolMachineMapper { get; private set; }

		protected IDALMachineMapper DalMachineMapper { get; private set; }

		private ILogger logger;

		public AbstractMachineService(
			ILogger logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
			IBOLMachineMapper bolMachineMapper,
			IDALMachineMapper dalMachineMapper)
			: base()
		{
			this.MachineRepository = machineRepository;
			this.MachineModelValidator = machineModelValidator;
			this.BolMachineMapper = bolMachineMapper;
			this.DalMachineMapper = dalMachineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachineResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MachineRepository.All(limit, offset);

			return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachineResponseModel> Get(string id)
		{
			var record = await this.MachineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model)
		{
			CreateResponse<ApiMachineResponseModel> response = new CreateResponse<ApiMachineResponseModel>(await this.MachineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolMachineMapper.MapModelToBO(default(string), model);
				var record = await this.MachineRepository.Create(this.DalMachineMapper.MapBOToEF(bo));

				response.SetRecord(this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMachineResponseModel>> Update(
			string id,
			ApiMachineRequestModel model)
		{
			var validationResult = await this.MachineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMachineMapper.MapModelToBO(id, model);
				await this.MachineRepository.Update(this.DalMachineMapper.MapBOToEF(bo));

				var record = await this.MachineRepository.Get(id);

				return new UpdateResponse<ApiMachineResponseModel>(this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiMachineResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.MachineModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.MachineRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiMachineResponseModel> ByName(string name)
		{
			Machine record = await this.MachineRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiMachineResponseModel>> ByMachinePolicyId(string machinePolicyId, int limit = 0, int offset = int.MaxValue)
		{
			List<Machine> records = await this.MachineRepository.ByMachinePolicyId(machinePolicyId, limit, offset);

			return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>9718fe1b4b991d48fd08e51c9ad2d667</Hash>
</Codenesium>*/