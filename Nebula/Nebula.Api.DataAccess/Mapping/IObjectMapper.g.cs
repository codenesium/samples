using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void ChainMapModelToEF(
			int id,
			ApiChainModel model,
			Chain efChain);

		POCOChain ChainMapEFToPOCO(
			Chain efChain);

		void ChainStatusMapModelToEF(
			int id,
			ApiChainStatusModel model,
			ChainStatus efChainStatus);

		POCOChainStatus ChainStatusMapEFToPOCO(
			ChainStatus efChainStatus);

		void ClaspMapModelToEF(
			int id,
			ApiClaspModel model,
			Clasp efClasp);

		POCOClasp ClaspMapEFToPOCO(
			Clasp efClasp);

		void LinkMapModelToEF(
			int id,
			ApiLinkModel model,
			Link efLink);

		POCOLink LinkMapEFToPOCO(
			Link efLink);

		void LinkLogMapModelToEF(
			int id,
			ApiLinkLogModel model,
			LinkLog efLinkLog);

		POCOLinkLog LinkLogMapEFToPOCO(
			LinkLog efLinkLog);

		void LinkStatusMapModelToEF(
			int id,
			ApiLinkStatusModel model,
			LinkStatus efLinkStatus);

		POCOLinkStatus LinkStatusMapEFToPOCO(
			LinkStatus efLinkStatus);

		void MachineMapModelToEF(
			int id,
			ApiMachineModel model,
			Machine efMachine);

		POCOMachine MachineMapEFToPOCO(
			Machine efMachine);

		void MachineRefTeamMapModelToEF(
			int id,
			ApiMachineRefTeamModel model,
			MachineRefTeam efMachineRefTeam);

		POCOMachineRefTeam MachineRefTeamMapEFToPOCO(
			MachineRefTeam efMachineRefTeam);

		void OrganizationMapModelToEF(
			int id,
			ApiOrganizationModel model,
			Organization efOrganization);

		POCOOrganization OrganizationMapEFToPOCO(
			Organization efOrganization);

		void TeamMapModelToEF(
			int id,
			ApiTeamModel model,
			Team efTeam);

		POCOTeam TeamMapEFToPOCO(
			Team efTeam);

		void VersionInfoMapModelToEF(
			long version,
			ApiVersionInfoModel model,
			VersionInfo efVersionInfo);

		POCOVersionInfo VersionInfoMapEFToPOCO(
			VersionInfo efVersionInfo);
	}
}

/*<Codenesium>
    <Hash>5a2bdc5e6e20b96c0b897a302ede1ada</Hash>
</Codenesium>*/