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
	public abstract class AbstractInvitationService : AbstractService
	{
		protected IInvitationRepository InvitationRepository { get; private set; }

		protected IApiInvitationRequestModelValidator InvitationModelValidator { get; private set; }

		protected IBOLInvitationMapper BolInvitationMapper { get; private set; }

		protected IDALInvitationMapper DalInvitationMapper { get; private set; }

		private ILogger logger;

		public AbstractInvitationService(
			ILogger logger,
			IInvitationRepository invitationRepository,
			IApiInvitationRequestModelValidator invitationModelValidator,
			IBOLInvitationMapper bolInvitationMapper,
			IDALInvitationMapper dalInvitationMapper)
			: base()
		{
			this.InvitationRepository = invitationRepository;
			this.InvitationModelValidator = invitationModelValidator;
			this.BolInvitationMapper = bolInvitationMapper;
			this.DalInvitationMapper = dalInvitationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiInvitationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.InvitationRepository.All(limit, offset);

			return this.BolInvitationMapper.MapBOToModel(this.DalInvitationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiInvitationResponseModel> Get(string id)
		{
			var record = await this.InvitationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolInvitationMapper.MapBOToModel(this.DalInvitationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiInvitationResponseModel>> Create(
			ApiInvitationRequestModel model)
		{
			CreateResponse<ApiInvitationResponseModel> response = new CreateResponse<ApiInvitationResponseModel>(await this.InvitationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolInvitationMapper.MapModelToBO(default(string), model);
				var record = await this.InvitationRepository.Create(this.DalInvitationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolInvitationMapper.MapBOToModel(this.DalInvitationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiInvitationResponseModel>> Update(
			string id,
			ApiInvitationRequestModel model)
		{
			var validationResult = await this.InvitationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolInvitationMapper.MapModelToBO(id, model);
				await this.InvitationRepository.Update(this.DalInvitationMapper.MapBOToEF(bo));

				var record = await this.InvitationRepository.Get(id);

				return new UpdateResponse<ApiInvitationResponseModel>(this.BolInvitationMapper.MapBOToModel(this.DalInvitationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiInvitationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.InvitationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.InvitationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f15f474050f3db5bdab141e96e4150a3</Hash>
</Codenesium>*/