import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeamMapper from './teamMapper';
import TeamViewModel from './teamViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ChainTableComponent } from '../shared/chainTable';

interface TeamDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TeamDetailComponentState {
  model?: TeamViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TeamDetailComponent extends React.Component<
  TeamDetailComponentProps,
  TeamDetailComponentState
> {
  state = {
    model: new TeamViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Teams + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Teams +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.TeamClientResponseModel;

          console.log(response);

          let mapper = new TeamMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>OrganizationId</h3>
              <p>
                {String(
                  this.state.model!.organizationIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>Chains</h3>
            <ChainTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Teams +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Chains
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedTeamDetailComponent = Form.create({ name: 'Team Detail' })(
  TeamDetailComponent
);


/*<Codenesium>
    <Hash>cc54296b2c339ca09e55621df783cdad</Hash>
</Codenesium>*/