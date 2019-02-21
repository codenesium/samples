import * as React from 'react';
import { Link } from 'react-router-dom';

interface Props{
}

interface State {
    menuExpanded:boolean;
}

 export class Header extends React.Component<Props, State> {
 
 state=({menuExpanded:false});
 
 handleClick(e:React.FormEvent)
 {
    this.setState({menuExpanded:!this.state.menuExpanded})
 }

 render()
 {   
     return (<div className="row col-12">
      <nav className="navbar navbar-expand-lg navbar-light bg-white" id="navbar">
        <a className="navbar-brand" href="/">Twitter</a>

        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" onClick={e => this.handleClick(e)}>
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className={ this.state.menuExpanded ? "collapse.expand navbar-collapse" : "collapse navbar-collapse" } id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
		  			 <li className="nav-item">
                <Link className="nav-link" to="/directtweets" onClick={e => this.handleClick(e)}>DirectTweets</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/followers" onClick={e => this.handleClick(e)}>Followers</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/followings" onClick={e => this.handleClick(e)}>Followings</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/locations" onClick={e => this.handleClick(e)}>Locations</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/messages" onClick={e => this.handleClick(e)}>Messages</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/messengers" onClick={e => this.handleClick(e)}>Messengers</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/quotetweets" onClick={e => this.handleClick(e)}>QuoteTweets</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/replies" onClick={e => this.handleClick(e)}>Replies</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/retweets" onClick={e => this.handleClick(e)}>Retweets</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/tweets" onClick={e => this.handleClick(e)}>Tweets</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/users" onClick={e => this.handleClick(e)}>Users</Link>
              </li>
			          </ul>
        </div>
      </nav>
    </div>);
  }
}

/*<Codenesium>
    <Hash>c2a48eea55310e82b9513900f8f0033b</Hash>
</Codenesium>*/