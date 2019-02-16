import * as React from 'react';
import { Link } from 'react-router-dom';

interface Props {}

interface State {
  menuExpanded: boolean;
}

export class Header extends React.Component<Props, State> {
  state = { menuExpanded: false };

  handleClick(e: React.FormEvent) {
    this.setState({ menuExpanded: !this.state.menuExpanded });
  }

  render() {
    return (
      <div className="row col-12">
        <nav
          className="navbar navbar-expand-lg navbar-light bg-white"
          id="navbar"
        >
          <a className="navbar-brand" href="/">
            PetShipping
          </a>

          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
            onClick={e => this.handleClick(e)}
          >
            <span className="navbar-toggler-icon" />
          </button>

          <div
            className={
              this.state.menuExpanded
                ? 'collapse.expand navbar-collapse'
                : 'collapse navbar-collapse'
            }
            id="navbarSupportedContent"
          >
            <ul className="navbar-nav mr-auto">
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/airlines"
                  onClick={e => this.handleClick(e)}
                >
                  Airlines
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/airtransports"
                  onClick={e => this.handleClick(e)}
                >
                  AirTransports
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/breeds"
                  onClick={e => this.handleClick(e)}
                >
                  Breeds
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/countries"
                  onClick={e => this.handleClick(e)}
                >
                  Countries
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/countryrequirements"
                  onClick={e => this.handleClick(e)}
                >
                  CountryRequirements
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/customers"
                  onClick={e => this.handleClick(e)}
                >
                  Customers
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/customercommunications"
                  onClick={e => this.handleClick(e)}
                >
                  CustomerCommunications
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/destinations"
                  onClick={e => this.handleClick(e)}
                >
                  Destinations
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/employees"
                  onClick={e => this.handleClick(e)}
                >
                  Employees
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/handlers"
                  onClick={e => this.handleClick(e)}
                >
                  Handlers
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/handlerpipelinesteps"
                  onClick={e => this.handleClick(e)}
                >
                  HandlerPipelineSteps
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/othertransports"
                  onClick={e => this.handleClick(e)}
                >
                  OtherTransports
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pets"
                  onClick={e => this.handleClick(e)}
                >
                  Pets
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pipelines"
                  onClick={e => this.handleClick(e)}
                >
                  Pipelines
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pipelinestatus"
                  onClick={e => this.handleClick(e)}
                >
                  PipelineStatus
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pipelinesteps"
                  onClick={e => this.handleClick(e)}
                >
                  PipelineSteps
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pipelinestepdestinations"
                  onClick={e => this.handleClick(e)}
                >
                  PipelineStepDestinations
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pipelinestepnotes"
                  onClick={e => this.handleClick(e)}
                >
                  PipelineStepNotes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pipelinestepstatus"
                  onClick={e => this.handleClick(e)}
                >
                  PipelineStepStatus
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pipelinestepsteprequirements"
                  onClick={e => this.handleClick(e)}
                >
                  PipelineStepStepRequirements
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/sales"
                  onClick={e => this.handleClick(e)}
                >
                  Sales
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/species"
                  onClick={e => this.handleClick(e)}
                >
                  Species
                </Link>
              </li>
            </ul>
          </div>
        </nav>
      </div>
    );
  }
}


/*<Codenesium>
    <Hash>f308f8aede647e85507b59be5fd499cc</Hash>
</Codenesium>*/