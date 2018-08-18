using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractEmployeeService : AbstractService
	{
		protected IEmployeeRepository EmployeeRepository { get; private set; }

		protected IApiEmployeeRequestModelValidator EmployeeModelValidator { get; private set; }

		protected IBOLEmployeeMapper BolEmployeeMapper { get; private set; }

		protected IDALEmployeeMapper DalEmployeeMapper { get; private set; }

		protected IBOLClientCommunicationMapper BolClientCommunicationMapper { get; private set; }

		protected IDALClientCommunicationMapper DalClientCommunicationMapper { get; private set; }

		protected IBOLPipelineStepMapper BolPipelineStepMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		protected IBOLPipelineStepNoteMapper BolPipelineStepNoteMapper { get; private set; }

		protected IDALPipelineStepNoteMapper DalPipelineStepNoteMapper { get; private set; }

		private ILogger logger;

		public AbstractEmployeeService(
			ILogger logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper bolEmployeeMapper,
			IDALEmployeeMapper dalEmployeeMapper,
			IBOLClientCommunicationMapper bolClientCommunicationMapper,
			IDALClientCommunicationMapper dalClientCommunicationMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base()
		{
			this.EmployeeRepository = employeeRepository;
			this.EmployeeModelValidator = employeeModelValidator;
			this.BolEmployeeMapper = bolEmployeeMapper;
			this.DalEmployeeMapper = dalEmployeeMapper;
			this.BolClientCommunicationMapper = bolClientCommunicationMapper;
			this.DalClientCommunicationMapper = dalClientCommunicationMapper;
			this.BolPipelineStepMapper = bolPipelineStepMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.BolPipelineStepNoteMapper = bolPipelineStepNoteMapper;
			this.DalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EmployeeRepository.All(limit, offset);

			return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeResponseModel> Get(int id)
		{
			var record = await this.EmployeeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model)
		{
			CreateResponse<ApiEmployeeResponseModel> response = new CreateResponse<ApiEmployeeResponseModel>(await this.EmployeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEmployeeMapper.MapModelToBO(default(int), model);
				var record = await this.EmployeeRepository.Create(this.DalEmployeeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmployeeResponseModel>> Update(
			int id,
			ApiEmployeeRequestModel model)
		{
			var validationResult = await this.EmployeeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEmployeeMapper.MapModelToBO(id, model);
				await this.EmployeeRepository.Update(this.DalEmployeeMapper.MapBOToEF(bo));

				var record = await this.EmployeeRepository.Get(id);

				return new UpdateResponse<ApiEmployeeResponseModel>(this.BolEmployeeMapper.MapBOToModel(this.DalEmployeeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEmployeeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.EmployeeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.EmployeeRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			List<ClientCommunication> records = await this.EmployeeRepository.ClientCommunications(employeeId, limit, offset);

			return this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int shipperId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.EmployeeRepository.PipelineSteps(shipperId, limit, offset);

			return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepNote> records = await this.EmployeeRepository.PipelineStepNotes(employeeId, limit, offset);

			return this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7ddac8ac0ddbb8fd3458d05828603270</Hash>
</Codenesium>*/