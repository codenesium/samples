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
            PetStore
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
                  to="/breeds"
                  onClick={e => this.handleClick(e)}
                >
                  Breeds
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/paymenttypes"
                  onClick={e => this.handleClick(e)}
                >
                  PaymentTypes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/pens"
                  onClick={e => this.handleClick(e)}
                >
                  Pens
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
    <Hash>617b9c56d781f04f91a3d73f18a419b7</Hash>
</Codenesium>*/