using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOPipelineStepNote: AbstractBOManager
	{
		private IPipelineStepNoteRepository pipelineStepNoteRepository;
		private IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator;
		private IBOLPipelineStepNoteMapper pipelineStepNoteMapper;
		private ILogger logger;

		public AbstractBOPipelineStepNote(
			ILogger logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper pipelineStepNoteMapper)
			: base()

		{
			this.pipelineStepNoteRepository = pipelineStepNoteRepository;
			this.pipelineStepNoteModelValidator = pipelineStepNoteModelValidator;
			this.pipelineStepNoteMapper = pipelineStepNoteMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepNoteResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStepNoteRepository.All(skip, take, orderClause);

			return this.pipelineStepNoteMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPipelineStepNoteResponseModel> Get(int id)
		{
			var record = await pipelineStepNoteRepository.Get(id);

			return this.pipelineStepNoteMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPipelineStepNoteResponseModel>> Create(
			ApiPipelineStepNoteRequestModel model)
		{
			CreateResponse<ApiPipelineStepNoteResponseModel> response = new CreateResponse<ApiPipelineStepNoteResponseModel>(await this.pipelineStepNoteModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.pipelineStepNoteMapper.MapModelToDTO(default (int), model);
				var record = await this.pipelineStepNoteRepository.Create(dto);

				response.SetRecord(this.pipelineStepNoteMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepNoteRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.pipelineStepNoteMapper.MapModelToDTO(id, model);
				await this.pipelineStepNoteRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStepNoteRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>987799bbffef84373b8fe165beea2780</Hash>
</Codenesium>*/