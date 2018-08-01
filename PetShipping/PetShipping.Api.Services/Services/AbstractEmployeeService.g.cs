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
		private IEmployeeRepository employeeRepository;

		private IApiEmployeeRequestModelValidator employeeModelValidator;

		private IBOLEmployeeMapper bolEmployeeMapper;

		private IDALEmployeeMapper dalEmployeeMapper;

		private IBOLClientCommunicationMapper bolClientCommunicationMapper;

		private IDALClientCommunicationMapper dalClientCommunicationMapper;
		private IBOLPipelineStepMapper bolPipelineStepMapper;

		private IDALPipelineStepMapper dalPipelineStepMapper;
		private IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper;

		private IDALPipelineStepNoteMapper dalPipelineStepNoteMapper;

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
			this.employeeRepository = employeeRepository;
			this.employeeModelValidator = employeeModelValidator;
			this.bolEmployeeMapper = bolEmployeeMapper;
			this.dalEmployeeMapper = dalEmployeeMapper;
			this.bolClientCommunicationMapper = bolClientCommunicationMapper;
			this.dalClientCommunicationMapper = dalClientCommunicationMapper;
			this.bolPipelineStepMapper = bolPipelineStepMapper;
			this.dalPipelineStepMapper = dalPipelineStepMapper;
			this.bolPipelineStepNoteMapper = bolPipelineStepNoteMapper;
			this.dalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.employeeRepository.All(limit, offset);

			return this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeResponseModel> Get(int id)
		{
			var record = await this.employeeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model)
		{
			CreateResponse<ApiEmployeeResponseModel> response = new CreateResponse<ApiEmployeeResponseModel>(await this.employeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolEmployeeMapper.MapModelToBO(default(int), model);
				var record = await this.employeeRepository.Create(this.dalEmployeeMapper.MapBOToEF(bo));

				response.SetRecord(this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmployeeResponseModel>> Update(
			int id,
			ApiEmployeeRequestModel model)
		{
			var validationResult = await this.employeeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolEmployeeMapper.MapModelToBO(id, model);
				await this.employeeRepository.Update(this.dalEmployeeMapper.MapBOToEF(bo));

				var record = await this.employeeRepository.Get(id);

				return new UpdateResponse<ApiEmployeeResponseModel>(this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEmployeeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.employeeRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			List<ClientCommunication> records = await this.employeeRepository.ClientCommunications(employeeId, limit, offset);

			return this.bolClientCommunicationMapper.MapBOToModel(this.dalClientCommunicationMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int shipperId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.employeeRepository.PipelineSteps(shipperId, limit, offset);

			return this.bolPipelineStepMapper.MapBOToModel(this.dalPipelineStepMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int employeeId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepNote> records = await this.employeeRepository.PipelineStepNotes(employeeId, limit, offset);

			return this.bolPipelineStepNoteMapper.MapBOToModel(this.dalPipelineStepNoteMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>cf36ed97740bf10645c1b086dc39d7a6</Hash>
</Codenesium>*/