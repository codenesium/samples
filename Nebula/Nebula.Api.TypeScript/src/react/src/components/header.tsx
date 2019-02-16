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
            Nebula
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
                  to="/chains"
                  onClick={e => this.handleClick(e)}
                >
                  Chains
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/chainstatuses"
                  onClick={e => this.handleClick(e)}
                >
                  ChainStatuses
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/clasps"
                  onClick={e => this.handleClick(e)}
                >
                  Clasps
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/links"
                  onClick={e => this.handleClick(e)}
                >
                  Links
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/linklogs"
                  onClick={e => this.handleClick(e)}
                >
                  LinkLogs
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/linkstatuses"
                  onClick={e => this.handleClick(e)}
                >
                  LinkStatuses
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/machines"
                  onClick={e => this.handleClick(e)}
                >
                  Machines
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/organizations"
                  onClick={e => this.handleClick(e)}
                >
                  Organizations
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/teams"
                  onClick={e => this.handleClick(e)}
                >
                  Teams
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
    <Hash>aec5aeba52335812d3b8d663b99b10b9</Hash>
</Codenesium>*/