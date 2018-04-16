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
				model.Name,
				model.TeamId,
				model.ChainStatusId,
				model.ExternalId);
		}

		public virtual void ChainMapEFToPOCO(
			EFChain efChain,
			ApiResponse response)
		{
			if (efChain == null)
			{
				return;
			}

			response.AddChain(new POCOChain(efChain.Id, efChain.Name, efChain.TeamId, efChain.ChainStatusId, efChain.ExternalId));

			this.TeamMapEFToPOCO(efChain.Team, response);

			this.ChainStatusMapEFToPOCO(efChain.ChainStatus, response);
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
				model.PreviousChainId,
				model.NextChainId);
		}

		public virtual void ClaspMapEFToPOCO(
			EFClasp efClasp,
			ApiResponse response)
		{
			if (efClasp == null)
			{
				return;
			}

			response.AddClasp(new POCOClasp(efClasp.Id, efClasp.PreviousChainId, efClasp.NextChainId));

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
				model.Name,
				model.DynamicParameters,
				model.StaticParameters,
				model.ChainId,
				model.AssignedMachineId,
				model.LinkStatusId,
				model.Order,
				model.DateStarted,
				model.DateCompleted,
				model.Response,
				model.ExternalId);
		}

		public virtual void LinkMapEFToPOCO(
			EFLink efLink,
			ApiResponse response)
		{
			if (efLink == null)
			{
				return;
			}

			response.AddLink(new POCOLink(efLink.Id, efLink.Name, efLink.DynamicParameters, efLink.StaticParameters, efLink.ChainId, efLink.AssignedMachineId, efLink.LinkStatusId, efLink.Order, efLink.DateStarted, efLink.DateCompleted, efLink.Response, efLink.ExternalId));

			this.ChainMapEFToPOCO(efLink.Chain, response);

			this.MachineMapEFToPOCO(efLink.Machine, response);

			this.LinkStatusMapEFToPOCO(efLink.LinkStatus, response);
		}

		public virtual void LinkLogMapModelToEF(
			int id,
			LinkLogModel model,
			EFLinkLog efLinkLog)
		{
			efLinkLog.SetProperties(
				id,
				model.LinkId,
				model.Log,
				model.DateEntered);
		}

		public virtual void LinkLogMapEFToPOCO(
			EFLinkLog efLinkLog,
			ApiResponse response)
		{
			if (efLinkLog == null)
			{
				return;
			}

			response.AddLinkLog(new POCOLinkLog(efLinkLog.Id, efLinkLog.LinkId, efLinkLog.Log, efLinkLog.DateEntered));

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
				model.Name,
				model.MachineGuid,
				model.JwtKey,
				model.LastIpAddress,
				model.Description);
		}

		public virtual void MachineMapEFToPOCO(
			EFMachine efMachine,
			ApiResponse response)
		{
			if (efMachine == null)
			{
				return;
			}

			response.AddMachine(new POCOMachine(efMachine.Id, efMachine.Name, efMachine.MachineGuid, efMachine.JwtKey, efMachine.LastIpAddress, efMachine.Description));
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
	}
}

/*<Codenesium>
    <Hash>2e9a4388fc8e5f8a5cf23aa835a10acd</Hash>
</Codenesium>*/