using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void ChainMapModelToEF(
			int id,
			ChainModel model,
			EFChain efChain)
		{
			efChain.SetProperties(
				id,
				model.ChainStatusId,
				model.ExternalId,
				model.Name,
				model.TeamId);
		}

		public virtual void ChainMapEFToPOCO(
			EFChain efChain,
			ApiResponse response)
		{
			if (efChain == null)
			{
				return;
			}

			response.AddChain(new POCOChain(efChain.ChainStatusId, efChain.ExternalId, efChain.Id, efChain.Name, efChain.TeamId));

			this.ChainStatusMapEFToPOCO(efChain.ChainStatus, response);

			this.TeamMapEFToPOCO(efChain.Team, response);
		}

		public virtual void ChainStatusMapModelToEF(
			int id,
			ChainStatusModel model,
			EFChainStatus efChainStatus)
		{
			efChainStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual void ChainStatusMapEFToPOCO(
			EFChainStatus efChainStatus,
			ApiResponse response)
		{
			if (efChainStatus == null)
			{
				return;
			}

			response.AddChainStatus(new POCOChainStatus(efChainStatus.Id, efChainStatus.Name));
		}

		public virtual void ClaspMapModelToEF(
			int id,
			ClaspModel model,
			EFClasp efClasp)
		{
			efClasp.SetProperties(
				id,
				model.NextChainId,
				model.PreviousChainId);
		}

		public virtual void ClaspMapEFToPOCO(
			EFClasp efClasp,
			ApiResponse response)
		{
			if (efClasp == null)
			{
				return;
			}

			response.AddClasp(new POCOClasp(efClasp.Id, efClasp.NextChainId, efClasp.PreviousChainId));

			this.ChainMapEFToPOCO(efClasp.Chain, response);

			this.ChainMapEFToPOCO(efClasp.Chain1, response);
		}

		public virtual void LinkMapModelToEF(
			int id,
			LinkModel model,
			EFLink efLink)
		{
			efLink.SetProperties(
				id,
				model.AssignedMachineId,
				model.ChainId,
				model.DateCompleted,
				model.DateStarted,
				model.DynamicParameters,
				model.ExternalId,
				model.LinkStatusId,
				model.Name,
				model.Order,
				model.Response,
				model.StaticParameters,
				model.TimeoutInSeconds);
		}

		public virtual void LinkMapEFToPOCO(
			EFLink efLink,
			ApiResponse response)
		{
			if (efLink == null)
			{
				return;
			}

			response.AddLink(new POCOLink(efLink.AssignedMachineId, efLink.ChainId, efLink.DateCompleted, efLink.DateStarted, efLink.DynamicParameters, efLink.ExternalId, efLink.Id, efLink.LinkStatusId, efLink.Name, efLink.Order, efLink.Response, efLink.StaticParameters, efLink.TimeoutInSeconds));

			this.MachineMapEFToPOCO(efLink.Machine, response);

			this.ChainMapEFToPOCO(efLink.Chain, response);

			this.LinkStatusMapEFToPOCO(efLink.LinkStatus, response);
		}

		public virtual void LinkLogMapModelToEF(
			int id,
			LinkLogModel model,
			EFLinkLog efLinkLog)
		{
			efLinkLog.SetProperties(
				id,
				model.DateEntered,
				model.LinkId,
				model.Log);
		}

		public virtual void LinkLogMapEFToPOCO(
			EFLinkLog efLinkLog,
			ApiResponse response)
		{
			if (efLinkLog == null)
			{
				return;
			}

			response.AddLinkLog(new POCOLinkLog(efLinkLog.DateEntered, efLinkLog.Id, efLinkLog.LinkId, efLinkLog.Log));

			this.LinkMapEFToPOCO(efLinkLog.Link, response);
		}

		public virtual void LinkStatusMapModelToEF(
			int id,
			LinkStatusModel model,
			EFLinkStatus efLinkStatus)
		{
			efLinkStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual void LinkStatusMapEFToPOCO(
			EFLinkStatus efLinkStatus,
			ApiResponse response)
		{
			if (efLinkStatus == null)
			{
				return;
			}

			response.AddLinkStatus(new POCOLinkStatus(efLinkStatus.Id, efLinkStatus.Name));
		}

		public virtual void MachineMapModelToEF(
			int id,
			MachineModel model,
			EFMachine efMachine)
		{
			efMachine.SetProperties(
				id,
				model.Description,
				model.JwtKey,
				model.LastIpAddress,
				model.MachineGuid,
				model.Name);
		}

		public virtual void MachineMapEFToPOCO(
			EFMachine efMachine,
			ApiResponse response)
		{
			if (efMachine == null)
			{
				return;
			}

			response.AddMachine(new POCOMachine(efMachine.Description, efMachine.Id, efMachine.JwtKey, efMachine.LastIpAddress, efMachine.MachineGuid, efMachine.Name));
		}

		public virtual void MachineRefTeamMapModelToEF(
			int id,
			MachineRefTeamModel model,
			EFMachineRefTeam efMachineRefTeam)
		{
			efMachineRefTeam.SetProperties(
				id,
				model.MachineId,
				model.TeamId);
		}

		public virtual void MachineRefTeamMapEFToPOCO(
			EFMachineRefTeam efMachineRefTeam,
			ApiResponse response)
		{
			if (efMachineRefTeam == null)
			{
				return;
			}

			response.AddMachineRefTeam(new POCOMachineRefTeam(efMachineRefTeam.Id, efMachineRefTeam.MachineId, efMachineRefTeam.TeamId));

			this.MachineMapEFToPOCO(efMachineRefTeam.Machine, response);

			this.TeamMapEFToPOCO(efMachineRefTeam.Team, response);
		}

		public virtual void OrganizationMapModelToEF(
			int id,
			OrganizationModel model,
			EFOrganization efOrganization)
		{
			efOrganization.SetProperties(
				id,
				model.Name);
		}

		public virtual void OrganizationMapEFToPOCO(
			EFOrganization efOrganization,
			ApiResponse response)
		{
			if (efOrganization == null)
			{
				return;
			}

			response.AddOrganization(new POCOOrganization(efOrganization.Id, efOrganization.Name));
		}

		public virtual void TeamMapModelToEF(
			int id,
			TeamModel model,
			EFTeam efTeam)
		{
			efTeam.SetProperties(
				id,
				model.Name,
				model.OrganizationId);
		}

		public virtual void TeamMapEFToPOCO(
			EFTeam efTeam,
			ApiResponse response)
		{
			if (efTeam == null)
			{
				return;
			}

			response.AddTeam(new POCOTeam(efTeam.Id, efTeam.Name, efTeam.OrganizationId));

			this.OrganizationMapEFToPOCO(efTeam.Organization, response);
		}

		public virtual void VersionInfoMapModelToEF(
			long version,
			VersionInfoModel model,
			EFVersionInfo efVersionInfo)
		{
			efVersionInfo.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
		}

		public virtual void VersionInfoMapEFToPOCO(
			EFVersionInfo efVersionInfo,
			ApiResponse response)
		{
			if (efVersionInfo == null)
			{
				return;
			}

			response.AddVersionInfo(new POCOVersionInfo(efVersionInfo.AppliedOn, efVersionInfo.Description, efVersionInfo.Version));
		}
	}
}

/*<Codenesium>
    <Hash>8f94b5638626e4f471be7cac53e71663</Hash>
</Codenesium>*/