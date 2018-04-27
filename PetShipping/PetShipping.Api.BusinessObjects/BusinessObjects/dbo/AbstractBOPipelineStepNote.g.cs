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
	public abstract class AbstractBOPipelineStepNote
	{
		private IPipelineStepNoteRepository pipelineStepNoteRepository;
		private IPipelineStepNoteModelValidator pipelineStepNoteModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepNote(
			ILogger logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IPipelineStepNoteModelValidator pipelineStepNoteModelValidator)

		{
			this.pipelineStepNoteRepository = pipelineStepNoteRepository;
			this.pipelineStepNoteModelValidator = pipelineStepNoteModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PipelineStepNoteModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.pipelineStepNoteModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.pipelineStepNoteRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineStepNoteModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStepNoteRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStepNoteRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.pipelineStepNoteRepository.GetById(id);
		}

		public virtual POCOPipelineStepNote GetByIdDirect(int id)
		{
			return this.pipelineStepNoteRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepNoteRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepNoteRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPipelineStepNote> GetWhereDirect(Expression<Func<EFPipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepNoteRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>bed54bcc9f326cc36990e6087ecb0b9c</Hash>
</Codenesium>*/