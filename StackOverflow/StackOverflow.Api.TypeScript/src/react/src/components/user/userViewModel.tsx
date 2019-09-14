import moment from 'moment';

export default class UserViewModel {
  aboutMe: string;
  accountId: number;
  age: number;
  creationDate: any;
  displayName: string;
  downVote: number;
  emailHash: string;
  id: number;
  lastAccessDate: any;
  location: string;
  reputation: number;
  upVote: number;
  view: number;
  websiteUrl: string;

  constructor() {
    this.aboutMe = '';
    this.accountId = 0;
    this.age = 0;
    this.creationDate = undefined;
    this.displayName = '';
    this.downVote = 0;
    this.emailHash = '';
    this.id = 0;
    this.lastAccessDate = undefined;
    this.location = '';
    this.reputation = 0;
    this.upVote = 0;
    this.view = 0;
    this.websiteUrl = '';
  }

  setProperties(
    aboutMe: string,
    accountId: number,
    age: number,
    creationDate: any,
    displayName: string,
    downVote: number,
    emailHash: string,
    id: number,
    lastAccessDate: any,
    location: string,
    reputation: number,
    upVote: number,
    view: number,
    websiteUrl: string
  ): void {
    this.aboutMe = aboutMe;
    this.accountId = accountId;
    this.age = age;
    this.creationDate = moment(creationDate, 'YYYY-MM-DD');
    this.displayName = displayName;
    this.downVote = downVote;
    this.emailHash = emailHash;
    this.id = id;
    this.lastAccessDate = moment(lastAccessDate, 'YYYY-MM-DD');
    this.location = location;
    this.reputation = reputation;
    this.upVote = upVote;
    this.view = view;
    this.websiteUrl = websiteUrl;
  }

  toDisplay(): string {
    return String(this.displayName);
  }
}


/*<Codenesium>
    <Hash>f441b835f56e62753134d3fe5abb64a2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/