using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void ChainMapModelToEF(
			int id,
			ApiChainModel model,
			Chain efChain)
		{
			efChain.SetProperties(
				id,
				model.ChainStatusId,
				model.ExternalId,
				model.Name,
				model.TeamId);
		}

		public virtual POCOChain ChainMapEFToPOCO(
			Chain efChain)
		{
			if (efChain == null)
			{
				return null;
			}

			return new POCOChain(efChain.ChainStatusId, efChain.ExternalId, efChain.Id, efChain.Name, efChain.TeamId);
		}

		public virtual void ChainStatusMapModelToEF(
			int id,
			ApiChainStatusModel model,
			ChainStatus efChainStatus)
		{
			efChainStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOChainStatus ChainStatusMapEFToPOCO(
			ChainStatus efChainStatus)
		{
			if (efChainStatus == null)
			{
				return null;
			}

			return new POCOChainStatus(efChainStatus.Id, efChainStatus.Name);
		}

		public virtual void ClaspMapModelToEF(
			int id,
			ApiClaspModel model,
			Clasp efClasp)
		{
			efClasp.SetProperties(
				id,
				model.NextChainId,
				model.PreviousChainId);
		}

		public virtual POCOClasp ClaspMapEFToPOCO(
			Clasp efClasp)
		{
			if (efClasp == null)
			{
				return null;
			}

			return new POCOClasp(efClasp.Id, efClasp.NextChainId, efClasp.PreviousChainId);
		}

		public virtual void LinkMapModelToEF(
			int id,
			ApiLinkModel model,
			Link efLink)
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

		public virtual POCOLink LinkMapEFToPOCO(
			Link efLink)
		{
			if (efLink == null)
			{
				return null;
			}

			return new POCOLink(efLink.AssignedMachineId, efLink.ChainId, efLink.DateCompleted, efLink.DateStarted, efLink.DynamicParameters, efLink.ExternalId, efLink.Id, efLink.LinkStatusId, efLink.Name, efLink.Order, efLink.Response, efLink.StaticParameters, efLink.TimeoutInSeconds);
		}

		public virtual void LinkLogMapModelToEF(
			int id,
			ApiLinkLogModel model,
			LinkLog efLinkLog)
		{
			efLinkLog.SetProperties(
				id,
				model.DateEntered,
				model.LinkId,
				model.Log);
		}

		public virtual POCOLinkLog LinkLogMapEFToPOCO(
			LinkLog efLinkLog)
		{
			if (efLinkLog == null)
			{
				return null;
			}

			return new POCOLinkLog(efLinkLog.DateEntered, efLinkLog.Id, efLinkLog.LinkId, efLinkLog.Log);
		}

		public virtual void LinkStatusMapModelToEF(
			int id,
			ApiLinkStatusModel model,
			LinkStatus efLinkStatus)
		{
			efLinkStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOLinkStatus LinkStatusMapEFToPOCO(
			LinkStatus efLinkStatus)
		{
			if (efLinkStatus == null)
			{
				return null;
			}

			return new POCOLinkStatus(efLinkStatus.Id, efLinkStatus.Name);
		}

		public virtual void MachineMapModelToEF(
			int id,
			ApiMachineModel model,
			Machine efMachine)
		{
			efMachine.SetProperties(
				id,
				model.Description,
				model.JwtKey,
				model.LastIpAddress,
				model.MachineGuid,
				model.Name);
		}

		public virtual POCOMachine MachineMapEFToPOCO(
			Machine efMachine)
		{
			if (efMachine == null)
			{
				return null;
			}

			return new POCOMachine(efMachine.Description, efMachine.Id, efMachine.JwtKey, efMachine.LastIpAddress, efMachine.MachineGuid, efMachine.Name);
		}

		public virtual void MachineRefTeamMapModelToEF(
			int id,
			ApiMachineRefTeamModel model,
			MachineRefTeam efMachineRefTeam)
		{
			efMachineRefTeam.SetProperties(
				id,
				model.MachineId,
				model.TeamId);
		}

		public virtual POCOMachineRefTeam MachineRefTeamMapEFToPOCO(
			MachineRefTeam efMachineRefTeam)
		{
			if (efMachineRefTeam == null)
			{
				return null;
			}

			return new POCOMachineRefTeam(efMachineRefTeam.Id, efMachineRefTeam.MachineId, efMachineRefTeam.TeamId);
		}

		public virtual void OrganizationMapModelToEF(
			int id,
			ApiOrganizationModel model,
			Organization efOrganization)
		{
			efOrganization.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOOrganization OrganizationMapEFToPOCO(
			Organization efOrganization)
		{
			if (efOrganization == null)
			{
				return null;
			}

			return new POCOOrganization(efOrganization.Id, efOrganization.Name);
		}

		public virtual void TeamMapModelToEF(
			int id,
			ApiTeamModel model,
			Team efTeam)
		{
			efTeam.SetProperties(
				id,
				model.Name,
				model.OrganizationId);
		}

		public virtual POCOTeam TeamMapEFToPOCO(
			Team efTeam)
		{
			if (efTeam == null)
			{
				return null;
			}

			return new POCOTeam(efTeam.Id, efTeam.Name, efTeam.OrganizationId);
		}

		public virtual void VersionInfoMapModelToEF(
			long version,
			ApiVersionInfoModel model,
			VersionInfo efVersionInfo)
		{
			efVersionInfo.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
		}

		public virtual POCOVersionInfo VersionInfoMapEFToPOCO(
			VersionInfo efVersionInfo)
		{
			if (efVersionInfo == null)
			{
				return null;
			}

			return new POCOVersionInfo(efVersionInfo.AppliedOn, efVersionInfo.Description, efVersionInfo.Version);
		}
	}
}

/*<Codenesium>
    <Hash>b5fbab796acba1f300265054a9c31fb6</Hash>
</Codenesium>*/