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
	public abstract class AbstractDestinationService : AbstractService
	{
		protected IDestinationRepository DestinationRepository { get; private set; }

		protected IApiDestinationRequestModelValidator DestinationModelValidator { get; private set; }

		protected IBOLDestinationMapper BolDestinationMapper { get; private set; }

		protected IDALDestinationMapper DalDestinationMapper { get; private set; }

		private ILogger logger;

		public AbstractDestinationService(
			ILogger logger,
			IDestinationRepository destinationRepository,
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper)
			: base()
		{
			this.DestinationRepository = destinationRepository;
			this.DestinationModelValidator = destinationModelValidator;
			this.BolDestinationMapper = bolDestinationMapper;
			this.DalDestinationMapper = dalDestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDestinationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DestinationRepository.All(limit, offset);

			return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDestinationResponseModel> Get(int id)
		{
			var record = await this.DestinationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDestinationResponseModel>> Create(
			ApiDestinationRequestModel model)
		{
			CreateResponse<ApiDestinationResponseModel> response = new CreateResponse<ApiDestinationResponseModel>(await this.DestinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDestinationMapper.MapModelToBO(default(int), model);
				var record = await this.DestinationRepository.Create(this.DalDestinationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDestinationResponseModel>> Update(
			int id,
			ApiDestinationRequestModel model)
		{
			var validationResult = await this.DestinationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDestinationMapper.MapModelToBO(id, model);
				await this.DestinationRepository.Update(this.DalDestinationMapper.MapBOToEF(bo));

				var record = await this.DestinationRepository.Get(id);

				return new UpdateResponse<ApiDestinationResponseModel>(this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDestinationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.DestinationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.DestinationRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiDestinationResponseModel>> ByDestinationId(int destinationId, int limit = int.MaxValue, int offset = 0)
		{
			List<Destination> records = await this.DestinationRepository.ByDestinationId(destinationId, limit, offset);

			return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>0e11d74679d8902bcfbe1c4d0812197a</Hash>
</Codenesium>*/