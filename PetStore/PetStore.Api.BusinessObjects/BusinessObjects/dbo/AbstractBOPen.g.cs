using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOPen: AbstractBOManager
	{
		private IPenRepository penRepository;
		private IApiPenRequestModelValidator penModelValidator;
		private IBOLPenMapper penMapper;
		private ILogger logger;

		public AbstractBOPen(
			ILogger logger,
			IPenRepository penRepository,
			IApiPenRequestModelValidator penModelValidator,
			IBOLPenMapper penMapper)
			: base()

		{
			this.penRepository = penRepository;
			this.penModelValidator = penModelValidator;
			this.penMapper = penMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPenResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.penRepository.All(skip, take, orderClause);

			return this.penMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPenResponseModel> Get(int id)
		{
			var record = await penRepository.Get(id);

			return this.penMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPenResponseModel>> Create(
			ApiPenRequestModel model)
		{
			CreateResponse<ApiPenResponseModel> response = new CreateResponse<ApiPenResponseModel>(await this.penModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.penMapper.MapModelToDTO(default (int), model);
				var record = await this.penRepository.Create(dto);

				response.SetRecord(this.penMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPenRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.penMapper.MapModelToDTO(id, model);
				await this.penRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.penRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3b02c5c33522be47042b3b35cd2b923d</Hash>
</Codenesium>*/