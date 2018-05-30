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
	public abstract class AbstractBODestination: AbstractBOManager
	{
		private IDestinationRepository destinationRepository;
		private IApiDestinationRequestModelValidator destinationModelValidator;
		private IBOLDestinationMapper destinationMapper;
		private ILogger logger;

		public AbstractBODestination(
			ILogger logger,
			IDestinationRepository destinationRepository,
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper destinationMapper)
			: base()

		{
			this.destinationRepository = destinationRepository;
			this.destinationModelValidator = destinationModelValidator;
			this.destinationMapper = destinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.destinationRepository.All(skip, take, orderClause);

			return this.destinationMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiDestinationResponseModel> Get(int id)
		{
			var record = await destinationRepository.Get(id);

			return this.destinationMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiDestinationResponseModel>> Create(
			ApiDestinationRequestModel model)
		{
			CreateResponse<ApiDestinationResponseModel> response = new CreateResponse<ApiDestinationResponseModel>(await this.destinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.destinationMapper.MapModelToDTO(default (int), model);
				var record = await this.destinationRepository.Create(dto);

				response.SetRecord(this.destinationMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiDestinationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.destinationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.destinationMapper.MapModelToDTO(id, model);
				await this.destinationRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.destinationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.destinationRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>af88ffc1da7041fb2efb97e350d2bbe4</Hash>
</Codenesium>*/