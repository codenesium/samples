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
        <a className="navbar-brand" href="/">ESPIOT</a>

        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" onClick={e => this.handleClick(e)}>
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className={ this.state.menuExpanded ? "collapse.expand navbar-collapse" : "collapse navbar-collapse" } id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
		  			 <li className="nav-item">
                <Link className="nav-link" to="/devices" onClick={e => this.handleClick(e)}>Devices</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/deviceactions" onClick={e => this.handleClick(e)}>DeviceActions</Link>
              </li>
			          </ul>
        </div>
      </nav>
    </div>);
  }
}

/*<Codenesium>
    <Hash>ab984ac252352bb3d19353092d7ab742</Hash>
</Codenesium>*/