import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeamMapper from './teamMapper';
import TeamViewModel from './teamViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.TeamClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Teams +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TeamMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Organization</h3>
              <p>
                {String(
                  this.state.model!.organizationIdNavigation &&
                    this.state.model!.organizationIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>Chains</h3>
            <ChainTableComponent
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
    <Hash>b584c14d69f28eb04251f4b8000c1df8</Hash>
</Codenesium>*/