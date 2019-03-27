import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MachineRefTeamMapper from './machineRefTeamMapper';
import MachineRefTeamViewModel from './machineRefTeamViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface MachineRefTeamDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface MachineRefTeamDetailComponentState {
  model?: MachineRefTeamViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class MachineRefTeamDetailComponent extends React.Component<
  MachineRefTeamDetailComponentProps,
  MachineRefTeamDetailComponentState
> {
  state = {
    model: new MachineRefTeamViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.MachineRefTeams + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.MachineRefTeamClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.MachineRefTeams +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new MachineRefTeamMapper();

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
            <div style={{ marginBottom: '10px' }}>
              <h3>Machine</h3>
              <p>
                {String(
                  this.state.model!.machineIdNavigation &&
                    this.state.model!.machineIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Team</h3>
              <p>
                {String(
                  this.state.model!.teamIdNavigation &&
                    this.state.model!.teamIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedMachineRefTeamDetailComponent = Form.create({
  name: 'MachineRefTeam Detail',
})(MachineRefTeamDetailComponent);


/*<Codenesium>
    <Hash>b1bab18378393e417ee1b75d6deb186b</Hash>
</Codenesium>*/