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
            TicketingCRM
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
                  to="/cities"
                  onClick={e => this.handleClick(e)}
                >
                  Cities
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
                  to="/customers"
                  onClick={e => this.handleClick(e)}
                >
                  Customers
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
                  to="/provinces"
                  onClick={e => this.handleClick(e)}
                >
                  Provinces
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
                  to="/saletickets"
                  onClick={e => this.handleClick(e)}
                >
                  SaleTickets
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/tickets"
                  onClick={e => this.handleClick(e)}
                >
                  Tickets
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/ticketstatus"
                  onClick={e => this.handleClick(e)}
                >
                  TicketStatus
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/transactions"
                  onClick={e => this.handleClick(e)}
                >
                  Transactions
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/transactionstatus"
                  onClick={e => this.handleClick(e)}
                >
                  TransactionStatus
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/venues"
                  onClick={e => this.handleClick(e)}
                >
                  Venues
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
    <Hash>c7362e73eeaf1b0fd7fb72ea46b7fbad</Hash>
</Codenesium>*/