export default class UserViewModel {
  aboutMe: string;
  accountId: any;
  age: any;
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
    this.accountId = undefined;
    this.age = undefined;
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
    accountId: any,
    age: any,
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
    this.creationDate = creationDate;
    this.displayName = displayName;
    this.downVote = downVote;
    this.emailHash = emailHash;
    this.id = id;
    this.lastAccessDate = lastAccessDate;
    this.location = location;
    this.reputation = reputation;
    this.upVote = upVote;
    this.view = view;
    this.websiteUrl = websiteUrl;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>3737d3a2fd123b6d1b9cde8b252d25e9</Hash>
</Codenesium>*/