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
            StudioResourceManagerMT
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
                  to="/admins"
                  onClick={e => this.handleClick(e)}
                >
                  Admins
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/events"
                  onClick={e => this.handleClick(e)}
                >
                  Events
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/eventstatus"
                  onClick={e => this.handleClick(e)}
                >
                  EventStatus
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/families"
                  onClick={e => this.handleClick(e)}
                >
                  Families
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/rates"
                  onClick={e => this.handleClick(e)}
                >
                  Rates
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/spaces"
                  onClick={e => this.handleClick(e)}
                >
                  Spaces
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/spacefeatures"
                  onClick={e => this.handleClick(e)}
                >
                  SpaceFeatures
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/students"
                  onClick={e => this.handleClick(e)}
                >
                  Students
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/studios"
                  onClick={e => this.handleClick(e)}
                >
                  Studios
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/teachers"
                  onClick={e => this.handleClick(e)}
                >
                  Teachers
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/teacherskills"
                  onClick={e => this.handleClick(e)}
                >
                  TeacherSkills
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/users"
                  onClick={e => this.handleClick(e)}
                >
                  Users
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
    <Hash>01228fa3a21c1fa30500a0c800cb11c5</Hash>
</Codenesium>*/