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
        <a className="navbar-brand" href="/">Tests</a>

        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" onClick={e => this.handleClick(e)}>
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className={ this.state.menuExpanded ? "collapse.expand navbar-collapse" : "collapse navbar-collapse" } id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
		  			 <li className="nav-item">
                <Link className="nav-link" to="/columnsameasfktables" onClick={e => this.handleClick(e)}>ColumnSameAsFKTables</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/includedcolumntests" onClick={e => this.handleClick(e)}>IncludedColumnTests</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/people" onClick={e => this.handleClick(e)}>People</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/rowversionchecks" onClick={e => this.handleClick(e)}>RowVersionChecks</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/selfreferences" onClick={e => this.handleClick(e)}>SelfReferences</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/tables" onClick={e => this.handleClick(e)}>Tables</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/testallfieldtypes" onClick={e => this.handleClick(e)}>TestAllFieldTypes</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/testallfieldtypesnullables" onClick={e => this.handleClick(e)}>TestAllFieldTypesNullables</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/timestampchecks" onClick={e => this.handleClick(e)}>TimestampChecks</Link>
              </li>
						 <li className="nav-item">
                <Link className="nav-link" to="/vpersons" onClick={e => this.handleClick(e)}>VPersons</Link>
              </li>
			          </ul>
        </div>
      </nav>
    </div>);
  }
}

/*<Codenesium>
    <Hash>3ee41bb9111b0d850fc361a912f5ad5c</Hash>
</Codenesium>*/