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
            StackOverflow
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
                  to="/badges"
                  onClick={e => this.handleClick(e)}
                >
                  Badges
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/comments"
                  onClick={e => this.handleClick(e)}
                >
                  Comments
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/linktypes"
                  onClick={e => this.handleClick(e)}
                >
                  LinkTypes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/posthistories"
                  onClick={e => this.handleClick(e)}
                >
                  PostHistories
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/posthistorytypes"
                  onClick={e => this.handleClick(e)}
                >
                  PostHistoryTypes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/postlinks"
                  onClick={e => this.handleClick(e)}
                >
                  PostLinks
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/posts"
                  onClick={e => this.handleClick(e)}
                >
                  Posts
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/posttypes"
                  onClick={e => this.handleClick(e)}
                >
                  PostTypes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/tags"
                  onClick={e => this.handleClick(e)}
                >
                  Tags
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
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/votes"
                  onClick={e => this.handleClick(e)}
                >
                  Votes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/votetypes"
                  onClick={e => this.handleClick(e)}
                >
                  VoteTypes
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
    <Hash>39f27c2e5375a5c8435490bc0c84d903</Hash>
</Codenesium>*/