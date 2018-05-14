using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void ChainMapModelToEF(
			int id,
			ChainModel model,
			Chain efChain);

		POCOChain ChainMapEFToPOCO(
			Chain efChain);

		void ChainStatusMapModelToEF(
			int id,
			ChainStatusModel model,
			ChainStatus efChainStatus);

		POCOChainStatus ChainStatusMapEFToPOCO(
			ChainStatus efChainStatus);

		void ClaspMapModelToEF(
			int id,
			ClaspModel model,
			Clasp efClasp);

		POCOClasp ClaspMapEFToPOCO(
			Clasp efClasp);

		void LinkMapModelToEF(
			int id,
			LinkModel model,
			Link efLink);

		POCOLink LinkMapEFToPOCO(
			Link efLink);

		void LinkLogMapModelToEF(
			int id,
			LinkLogModel model,
			LinkLog efLinkLog);

		POCOLinkLog LinkLogMapEFToPOCO(
			LinkLog efLinkLog);

		void LinkStatusMapModelToEF(
			int id,
			LinkStatusModel model,
			LinkStatus efLinkStatus);

		POCOLinkStatus LinkStatusMapEFToPOCO(
			LinkStatus efLinkStatus);

		void MachineMapModelToEF(
			int id,
			MachineModel model,
			Machine efMachine);

		POCOMachine MachineMapEFToPOCO(
			Machine efMachine);

		void MachineRefTeamMapModelToEF(
			int id,
			MachineRefTeamModel model,
			MachineRefTeam efMachineRefTeam);

		POCOMachineRefTeam MachineRefTeamMapEFToPOCO(
			MachineRefTeam efMachineRefTeam);

		void OrganizationMapModelToEF(
			int id,
			OrganizationModel model,
			Organization efOrganization);

		POCOOrganization OrganizationMapEFToPOCO(
			Organization efOrganization);

		void TeamMapModelToEF(
			int id,
			TeamModel model,
			Team efTeam);

		POCOTeam TeamMapEFToPOCO(
			Team efTeam);

		void VersionInfoMapModelToEF(
			long version,
			VersionInfoModel model,
			VersionInfo efVersionInfo);

		POCOVersionInfo VersionInfoMapEFToPOCO(
			VersionInfo efVersionInfo);
	}
}

/*<Codenesium>
    <Hash>ccb7b728b090d3638f36bf6487944176</Hash>
</Codenesium>*/