import moment from 'moment'


export default class VideoViewModel {
    description:string;
id:number;
title:string;
url:string;

    constructor() {
		this.description = '';
this.id = 0;
this.title = '';
this.url = '';

    }

	setProperties(description : string,id : number,title : string,url : string) : void
	{
		this.description = description;
this.id = id;
this.title = title;
this.url = url;

	}

	toDisplay() : string
	{
		return String(this.title);
	}
};

/*<Codenesium>
    <Hash>efe9537cb048c2065dbf41d57e3eafc8</Hash>
</Codenesium>*/