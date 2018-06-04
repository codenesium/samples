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

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDestinationService: AbstractService
	{
		private IDestinationRepository destinationRepository;
		private IApiDestinationRequestModelValidator destinationModelValidator;
		private IBOLDestinationMapper BOLDestinationMapper;
		private IDALDestinationMapper DALDestinationMapper;
		private ILogger logger;

		public AbstractDestinationService(
			ILogger logger,
			IDestinationRepository destinationRepository,
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper boldestinationMapper,
			IDALDestinationMapper daldestinationMapper)
			: base()

		{
			this.destinationRepository = destinationRepository;
			this.destinationModelValidator = destinationModelValidator;
			this.BOLDestinationMapper = boldestinationMapper;
			this.DALDestinationMapper = daldestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.destinationRepository.All(skip, take, orderClause);

			return this.BOLDestinationMapper.MapBOToModel(this.DALDestinationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDestinationResponseModel> Get(int id)
		{
			var record = await destinationRepository.Get(id);

			return this.BOLDestinationMapper.MapBOToModel(this.DALDestinationMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiDestinationResponseModel>> Create(
			ApiDestinationRequestModel model)
		{
			CreateResponse<ApiDestinationResponseModel> response = new CreateResponse<ApiDestinationResponseModel>(await this.destinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLDestinationMapper.MapModelToBO(default (int), model);
				var record = await this.destinationRepository.Create(this.DALDestinationMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLDestinationMapper.MapBOToModel(this.DALDestinationMapper.MapEFToBO(record)));
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
				var bo = this.BOLDestinationMapper.MapModelToBO(id, model);
				await this.destinationRepository.Update(this.DALDestinationMapper.MapBOToEF(bo));
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
    <Hash>183eba874d9d02716102bec193b9ec2e</Hash>
</Codenesium>*/